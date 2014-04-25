namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class AccelerometerDataEventArgs : MyoEventArgs
    {
        public AccelerometerDataEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp, Vector3 accelerometer) : base(myo, timestamp)
        {
            this.Accelerometer = accelerometer;
        }

        public Vector3 Accelerometer { get; private set; }
    }
}

