namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class OrientationDataEventArgs : MyoEventArgs
    {
        public OrientationDataEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp, Quaternion orientation) : base(myo, timestamp)
        {
            this.Orientation = orientation;
        }

        public Quaternion Orientation { get; private set; }
    }
}

