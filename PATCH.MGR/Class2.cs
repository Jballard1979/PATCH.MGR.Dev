using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SCADA.PATCHING
{
    public class YourClass
    {
        public async Task SomeMethod()
        {
            Process process = new Process();
            process.Start();
            // WAIT FOR PROCESS TO EXIT ASYNCHRONOUSLY:
            await process.WaitForExitAsync();
        }
    }
}
