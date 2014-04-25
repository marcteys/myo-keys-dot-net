namespace Thalmic.Myo
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal class TrainingData
    {
        private IntPtr _handle;
        private Thalmic.Myo.Myo _myo;

        internal event EventHandler<TrainingEventArgs> CollectionProgress;

        internal TrainingData(Thalmic.Myo.Myo myo)
        {
            this._myo = myo;
            if (libmyo.training_create_dataset(this._myo.Handle, out this._handle, IntPtr.Zero) != libmyo.Result.Success)
            {
                throw new InvalidOperationException("Unable to create training data.");
            }
        }

        internal void Annotate(string name, string value)
        {
            libmyo.training_annotate_training_data(this._handle, name, value, IntPtr.Zero);
        }

        internal void Collect(Pose pose)
        {
            GCHandle handle = GCHandle.Alloc(this);
            try
            {
                this._myo.Hub.StopEventThread();
                libmyo.training_collect_data(this._handle, (libmyo.PoseType) pose, new libmyo.TrainingCollectStatus(TrainingData.HandleTrainingData), (IntPtr) handle, IntPtr.Zero);
            }
            finally
            {
                handle.Free();
                this._myo.Hub.StartEventThread();
            }
        }

        private static libmyo.HandlerResult HandleTrainingData(IntPtr userData, byte data, byte progress)
        {
            GCHandle handle = (GCHandle) userData;
            TrainingData target = (TrainingData) handle.Target;
            if (target.CollectionProgress != null)
            {
                target.CollectionProgress(target, new TrainingEventArgs(target._myo, DateTime.Now, data, progress));
            }
            return libmyo.HandlerResult.Continue;
        }

        internal void Send()
        {
            libmyo.training_send_training_data(this._handle, IntPtr.Zero);
        }

        internal void Train()
        {
            libmyo.training_train_from_dataset(this._handle, IntPtr.Zero);
        }
    }
}

