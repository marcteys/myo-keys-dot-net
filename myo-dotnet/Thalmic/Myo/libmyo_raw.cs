namespace Thalmic.Myo
{
    using System;
    using System.Runtime.InteropServices;

    internal static class libmyo_raw
    {
        private const string MYO_RAW_DLL = "myo_raw32.dll";

        [DllImport("myo_raw32.dll", EntryPoint="libmyo_raw_event_get_emg", CallingConvention=CallingConvention.Cdecl)]
        public static extern sbyte event_get_emg(IntPtr evt, uint sample, uint sensor);
        [DllImport("myo_raw32.dll", EntryPoint="libmyo_raw_event_get_fv", CallingConvention=CallingConvention.Cdecl)]
        public static extern ushort event_get_fv(IntPtr evt, uint index);
        [DllImport("myo_raw32.dll", EntryPoint="libmyo_raw_event_get_type", CallingConvention=CallingConvention.Cdecl)]
        public static extern EventType event_get_type(IntPtr evt);
        [DllImport("myo_raw32.dll", EntryPoint="libmyo_raw_myo_enable_raw_emg", CallingConvention=CallingConvention.Cdecl)]
        public static extern libmyo.Result myo_enable_raw_emg(IntPtr myo, int enableEmg, IntPtr error);
        [DllImport("myo_raw32.dll", EntryPoint="libmyo_raw_run", CallingConvention=CallingConvention.Cdecl)]
        public static extern libmyo.Result run(IntPtr hub, uint durationMs, libmyo.Handler handler, IntPtr userData, IntPtr error);

        public enum EventType
        {
            NotRaw,
            Fv
        }
    }
}

