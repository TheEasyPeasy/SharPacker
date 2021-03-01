using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharPacker
{
    class DebugChecker
    {

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDebuggerPresent();

        //really simple methods...
        public static void checkDebugger()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Application.Exit();
            }

            if (IsDebuggerPresent())
            {
                Application.Exit();
            }
            watch.Stop();
            if(watch.ElapsedMilliseconds > 2500)
            {
                Application.Exit();
            }
        }

    }
}
