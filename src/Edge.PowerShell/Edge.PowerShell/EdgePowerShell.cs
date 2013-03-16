using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Edge.PS
{
    public class EdgePowerShell
    {
        public async Task<object> InvokeScript(string script)
        {
            var powerShell = PowerShell.
                Create().
                AddScript(script);

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
