using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SCADA.PATCHING
{
    public static class ProcessExtensions
    {
        public static Task<bool> WaitForExitAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<bool>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(true);
            if (process.HasExited)
            {
                tcs.TrySetResult(true);
            }
            return tcs.Task;
        }
    }
}
