using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Owin.PS
{
    public class OwinPowerShell
    {
        public Task<object> InvokeScript(string script)
        {
            var powerShell = PowerShell.
                Create().
                AddScript(script);

            var result = powerShell.Invoke();

            List<object> list = new List<object>();

            foreach (var item in result)
            {
                list.Add(item.BaseObject);
            }

            return Task.FromResult<object>(list);
        }
    }
}
