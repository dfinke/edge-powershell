using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace Edge.PS
{
    public class EdgePowerShell
    {
        //public async Task<object> InvokeScript(string script)
        //{
        //    System.Console.WriteLine(System.Environment.CurrentDirectory);
        //    System.Console.WriteLine(script);
        //    var powerShell = PowerShell.
        //        Create().
        //        AddScript(script);

        //    var outputs = await Task.Factory.FromAsync<PSDataCollection<PSObject>, PSInvocationSettings, PSDataCollection<PSObject>>(
        //        powerShell.BeginInvoke,
        //        powerShell.EndInvoke,
        //        new PSDataCollection<PSObject>(),
        //        new PSInvocationSettings(),
        //        null,
        //        TaskCreationOptions.None);

        //    List<object> results = outputs.Select(pso => pso.BaseObject).ToList();

        //    return Task.FromResult<object>(results);
        //}

        public async Task<object> InvokeScript(object input)
        {

            IDictionary<string, object> payload = (IDictionary<string, object>)input;

            string script = payload["script"] as string;            

            var parameters = (Dictionary<string, object>)payload["parameters"]; 
            var powerShell = PowerShell.Create();

            var sb = new StringBuilder(script);

            foreach (var item in (Dictionary<string, object>)payload["parameters"])
            {
                sb.AppendFormat(" -{0} {1} ", item.Key, item.Value);            
            }

            var targetScript = sb.ToString();
            System.Console.WriteLine("script: {0}", targetScript);
            powerShell.AddScript(targetScript);

            var outputs = await Task.Factory.FromAsync<PSDataCollection<PSObject>, PSInvocationSettings, PSDataCollection<PSObject>>(
                powerShell.BeginInvoke,
                powerShell.EndInvoke,
                new PSDataCollection<PSObject>(),
                new PSInvocationSettings(),
                null,
                TaskCreationOptions.None);

            List<object> results = outputs.Select(pso => pso.BaseObject).ToList();

            return Task.FromResult<object>(results);
        }
    }
}
