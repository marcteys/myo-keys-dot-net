namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class PoseEventArgs : MyoEventArgs
    {
        public PoseEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp, Thalmic.Myo.Pose pose) : base(myo, timestamp)
        {
            this.Pose = pose;
        }

        public Thalmic.Myo.Pose Pose { get; private set; }
    }
}

