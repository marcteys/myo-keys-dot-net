namespace Thalmic.Myo
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class Hub : IDisposable
    {
        private bool _disposed;
        private Thread _eventThread;
        private bool _eventThreadShutdown;
        private IntPtr _handle;
        private Dictionary<IntPtr, Thalmic.Myo.Myo> _myos;
        private readonly bool _withoutTrainingProfile;
        private static readonly DateTime TIMESTAMP_EPOCH = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);

        public event EventHandler<MyoEventArgs> Paired;

        public Hub() : this(false)
        {
        }

        internal Hub(bool withoutTrainingProfile)
        {
            this._myos = new Dictionary<IntPtr, Thalmic.Myo.Myo>();
            this._withoutTrainingProfile = withoutTrainingProfile;
            if (libmyo.init_hub(out this._handle, IntPtr.Zero) != libmyo.Result.Success)
            {
                throw new InvalidOperationException("Unable to initialize Hub");
            }
            this.StartEventThread();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                this._eventThreadShutdown = true;
                if (this._eventThread != null)
                {
                    this._eventThread.Join();
                }
                this.StopEventThread();
                libmyo.shutdown_hub(this._handle, IntPtr.Zero);
                this._disposed = true;
            }
        }

        private void EventThreadFn()
        {
            while (!this._eventThreadShutdown)
            {
                GCHandle handle = GCHandle.Alloc(this);
                libmyo.run(this._handle, 0x3e8, new libmyo.Handler(Hub.HandleEvent), (IntPtr) handle, IntPtr.Zero);
            }
        }

        ~Hub()
        {
            this.Dispose(false);
        }

        private static libmyo.HandlerResult HandleEvent(IntPtr userData, IntPtr evt)
        {
            GCHandle handle = (GCHandle) userData;
            Hub target = (Hub) handle.Target;
            libmyo.EventType type = libmyo.event_get_type(evt);
            DateTime timestamp = TIMESTAMP_EPOCH.AddMilliseconds((double) (libmyo.event_get_timestamp(evt) / ((ulong) 0x3e8L)));
            IntPtr ptr = libmyo.event_get_myo(evt);
            if (type == libmyo.EventType.Paired)
            {
                Thalmic.Myo.Myo myo = new Thalmic.Myo.Myo(target, ptr, target._withoutTrainingProfile);
                target._myos.Add(ptr, myo);
                if (target.Paired != null)
                {
                    target.Paired(target, new MyoEventArgs(myo, DateTime.Now));
                }
            }
            else
            {
                target._myos[ptr].HandleEvent(type, timestamp, evt);
            }
            return libmyo.HandlerResult.Continue;
        }

        public void PairByMacAddress(ulong macAddress)
        {
            libmyo.pair_by_mac_address(this._handle, macAddress, IntPtr.Zero);
        }

        public void PairWithAdjacentMyo()
        {
            this.PairWithAdjacentMyos(1);
        }

        public void PairWithAdjacentMyos(uint count)
        {
            libmyo.pair_adjacent(this._handle, count, IntPtr.Zero);
        }

        public void PairWithAnyMyo()
        {
            this.PairWithAnyMyos(1);
        }

        public void PairWithAnyMyos(uint count)
        {
            libmyo.pair_any(this._handle, count, IntPtr.Zero);
        }

        internal void StartEventThread()
        {
            this._eventThreadShutdown = false;
            this._eventThread = new Thread(new ThreadStart(this.EventThreadFn));
            this._eventThread.Start();
        }

        internal void StopEventThread()
        {
            this._eventThreadShutdown = true;
            if (this._eventThread != null)
            {
                this._eventThread.Join();
            }
        }
    }
}

