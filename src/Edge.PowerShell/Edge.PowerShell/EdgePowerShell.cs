using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Edge.PS
{
    public class EdgePowerShell
    {
        public async Task<object> InvokeScript(object input)
        {
            var powerShell = PowerShell.Create();
            var payload = input as IDictionary<string, object>;

            var script = payload == null ? GetScriptFromInput(input.ToString()) : GetScriptFromPayload(payload);

            powerShell.AddScript(script);
            powerShell.AddCommand("Out-String");

            var outputs = await Task.Factory.FromAsync<PSDataCollection<PSObject>, PSInvocationSettings, PSDataCollection<PSObject>>(
                powerShell.BeginInvoke,
                powerShell.EndInvoke,
                new PSDataCollection<PSObject>(),
                new PSInvocationSettings(),
                null,
                TaskCreationOptions.None);

            var results = outputs.Select(psobject => psobject).ToList();
            return Task.FromResult<object>(results);
        }

        private string GetScriptFromInput(string input)
        {
            return GetScriptFile(input);
        }

        private string GetScriptFile(string script)
        {
            var tmpScript = string.Format(@".\{0}.ps1", script);
            return File.Exists(tmpScript) ? tmpScript : script;
        }

        private string GetScriptFromPayload(IDictionary<string, object> payload)
        {
            var script = GetScriptFile(payload["script"] as string);

            var targetScript = script;

            if (payload.ContainsKey("parameters"))
            {
                var parameters = payload["parameters"] as Dictionary<string, object>;

                var sb = new StringBuilder(script);

                foreach (var item in parameters)
                {
                    sb.AppendFormat(" -{0} {1} ", item.Key, item.Value);
                }

                targetScript = sb.ToString();

            }

            //Console.WriteLine("script: {0}", targetScript);

            return targetScript;
        }
    }
}
