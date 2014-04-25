namespace Thalmic.Myo
{
    using System;
    using System.Runtime.CompilerServices;

    public class TrainingEventArgs : MyoEventArgs
    {
        public TrainingEventArgs(Thalmic.Myo.Myo myo, DateTime timestamp, byte value, byte progress) : base(myo, timestamp)
        {
            this.Value = value;
            this.Progress = progress;
        }

        public byte Progress { get; private set; }

        public byte Value { get; private set; }
    }
}

