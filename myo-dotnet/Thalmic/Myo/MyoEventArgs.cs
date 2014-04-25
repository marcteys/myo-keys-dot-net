namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class MyoEventArgs : EventArgs
    {
        public MyoEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp)
        {
            this.Myo = myo;
            this.Timestamp = timestamp;
        }

        public Thalmic.Myo.Myo Myo { get; private set; }

        public DateTime Timestamp { get; private set; }
    }
}

