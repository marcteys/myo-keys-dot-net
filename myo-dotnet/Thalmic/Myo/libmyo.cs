namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal static class libmyo
    {
        private const string MYO_DLL = "myo32.dll";

        [DllImport("myo32.dll", EntryPoint="libmyo_error_cstring", CallingConvention=CallingConvention.Cdecl)]
        public static extern string error_cstring(IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_error_kind", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result error_kind(IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_accelerometer", CallingConvention=CallingConvention.Cdecl)]
        public static extern float event_get_accelerometer(IntPtr evt, uint index);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_gyroscope", CallingConvention=CallingConvention.Cdecl)]
        public static extern float event_get_gyroscope(IntPtr evt, uint index);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_myo", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr event_get_myo(IntPtr evt);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_orientation", CallingConvention=CallingConvention.Cdecl)]
        public static extern float event_get_orientation(IntPtr evt, OrientationIndex index);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_pose", CallingConvention=CallingConvention.Cdecl)]
        public static extern PoseType event_get_pose(IntPtr evt);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_timestamp", CallingConvention=CallingConvention.Cdecl)]
        public static extern ulong event_get_timestamp(IntPtr evt);
        [DllImport("myo32.dll", EntryPoint="libmyo_event_get_type", CallingConvention=CallingConvention.Cdecl)]
        public static extern EventType event_get_type(IntPtr evt);
        [DllImport("myo32.dll", EntryPoint="libmyo_free_error_details", CallingConvention=CallingConvention.Cdecl)]
        public static extern void free_error_details(IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_get_mac_address", CallingConvention=CallingConvention.Cdecl)]
        public static extern ulong get_mac_address(IntPtr myo);
        [DllImport("myo32.dll", EntryPoint="libmyo_init_hub", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result init_hub(out IntPtr hub, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_now", CallingConvention=CallingConvention.Cdecl)]
        public static extern ulong now();
        [DllImport("myo32.dll", EntryPoint="libmyo_pair_adjacent", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result pair_adjacent(IntPtr hub, uint count, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_pair_any", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result pair_any(IntPtr hub, uint count, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_pair_by_mac_address", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result pair_by_mac_address(IntPtr hub, ulong macAddress, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_run", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result run(IntPtr hub, uint durationMs, Handler handler, IntPtr userData, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_shutdown_hub", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result shutdown_hub(IntPtr hub, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_string_to_mac_address", CallingConvention=CallingConvention.Cdecl)]
        public static extern ulong string_to_mac_address(string addressAsString);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_annotate_training_data", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_annotate_training_data(IntPtr dataset, string name, string value, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_collect_data", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_collect_data(IntPtr dataset, PoseType pose, TrainingCollectStatus callback, IntPtr userData, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_create_dataset", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_create_dataset(IntPtr hub, out IntPtr dataset, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_free_dataset", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_free_dataset(IntPtr dataset);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_is_available", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool training_is_available(IntPtr hub);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_load_profile", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_load_profile(IntPtr myo, string filename, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_send_training_data", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_send_training_data(IntPtr dataset, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_store_profile", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_store_profile(IntPtr myo, IntPtr filename, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_training_train_from_dataset", CallingConvention=CallingConvention.Cdecl)]
        public static extern Result training_train_from_dataset(IntPtr dataset, IntPtr error);
        [DllImport("myo32.dll", EntryPoint="libmyo_vibrate", CallingConvention=CallingConvention.Cdecl)]
        public static extern void vibrate(IntPtr myo, VibrationType type, IntPtr error);

        public enum EventType
        {
            Paired,
            Connected,
            Disconnected,
            Orientation,
            Pose
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate libmyo.HandlerResult Handler(IntPtr userData, IntPtr evt);

        public enum HandlerResult
        {
            Continue,
            Stop
        }

        public enum OrientationIndex
        {
            X,
            Y,
            Z,
            W
        }

        public enum PoseType
        {
            None,
            Fist,
            WaveIn,
            WaveOut,
            FingersSpread
        }

        public enum Result
        {
            Success,
            Error,
            ErrorInvalidArgument,
            ErrorRuntime
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate libmyo.HandlerResult TrainingCollectStatus(IntPtr userData, byte value, byte progress);

        public enum VibrationType
        {
            Short,
            Medium,
            Long
        }
    }
}

