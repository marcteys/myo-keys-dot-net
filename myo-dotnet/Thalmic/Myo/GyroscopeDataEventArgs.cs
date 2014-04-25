namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class GyroscopeDataEventArgs : MyoEventArgs
    {
        public GyroscopeDataEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp, Vector3 gyroscope) : base(myo, timestamp)
        {
            this.Gyroscope = gyroscope;
        }

        public Vector3 Gyroscope { get; private set; }
    }
}

