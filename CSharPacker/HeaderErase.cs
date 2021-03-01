using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharPacker
{
    class HeaderErase
    {

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public static void erasePE()
        {
            IntPtr oldProtect = (IntPtr)0;
            IntPtr baseAddress = (IntPtr)GetModuleHandle(null);
            VirtualProtect(baseAddress, (IntPtr)4096, (IntPtr)0x04, ref oldProtect);
            ZeroMemory(baseAddress, (IntPtr)4096);
        }

    }
}
