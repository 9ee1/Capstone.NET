using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Capstone Proxy Import.
    /// </summary>
    public static class CapstoneProxyImport {
        [DllImport("Gee.External.Capstone.Proxy.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CapstoneArmDetail")]
        public static extern IntPtr ArmDetail(IntPtr pDetail);

        [DllImport("Gee.External.Capstone.Proxy.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CapstoneArm64Detail")]
        public static extern IntPtr Arm64Detail(IntPtr pDetail);

        [DllImport("Gee.External.Capstone.Proxy.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CapstoneX86Detail")]
        public static extern IntPtr X86Detail(IntPtr pDetail);
    }
}