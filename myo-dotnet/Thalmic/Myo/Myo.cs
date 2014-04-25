namespace Thalmic.Myo
{
    using System;
    using System.Threading;

    public class Myo
    {
        private IntPtr _handle;
        private readonly Thalmic.Myo.Hub _hub;
        private Thalmic.Myo.TrainingData _trainingData;

        public event EventHandler<AccelerometerDataEventArgs> AccelerometerData;

        public event EventHandler<MyoEventArgs> Connected;

        public event EventHandler<MyoEventArgs> Disconnected;

        public event EventHandler<GyroscopeDataEventArgs> GyroscopeData;

        public event EventHandler<OrientationDataEventArgs> OrientationData;

        public event EventHandler<PoseEventArgs> PoseChange;

        internal Myo(Thalmic.Myo.Hub hub, IntPtr handle, bool withoutTrainingProfile)
        {
            this._hub = hub;
            this._handle = handle;
            if (!withoutTrainingProfile && (libmyo.training_load_profile(this._handle, null, IntPtr.Zero) != libmyo.Result.Success))
            {
                throw new InvalidOperationException("Warning: No training profile found. Please run the training application.");
            }
        }

        internal void HandleEvent(libmyo.EventType type, DateTime timestamp, IntPtr evt)
        {
            switch (type)
            {
                case libmyo.EventType.Connected:
                    if (this.Connected == null)
                    {
                        break;
                    }
                    this.Connected(this, new MyoEventArgs(this, timestamp));
                    return;

                case libmyo.EventType.Disconnected:
                    if (this.Disconnected == null)
                    {
                        break;
                    }
                    this.Disconnected(this, new MyoEventArgs(this, timestamp));
                    return;

                case libmyo.EventType.Orientation:
                {
                    if (this.AccelerometerData != null)
                    {
                        float num = libmyo.event_get_accelerometer(evt, 0);
                        float num2 = libmyo.event_get_accelerometer(evt, 1);
                        float num3 = libmyo.event_get_accelerometer(evt, 2);
                        Vector3 accelerometer = new Vector3(num, num2, num3);
                        this.AccelerometerData(this, new AccelerometerDataEventArgs(this, timestamp, accelerometer));
                    }
                    if (this.GyroscopeData != null)
                    {
                        float num4 = libmyo.event_get_gyroscope(evt, 0);
                        float num5 = libmyo.event_get_gyroscope(evt, 1);
                        float num6 = libmyo.event_get_gyroscope(evt, 2);
                        Vector3 gyroscope = new Vector3(num4, num5, num6);
                        this.GyroscopeData(this, new GyroscopeDataEventArgs(this, timestamp, gyroscope));
                    }
                    if (this.OrientationData == null)
                    {
                        break;
                    }
                    float x = libmyo.event_get_orientation(evt, libmyo.OrientationIndex.X);
                    float y = libmyo.event_get_orientation(evt, libmyo.OrientationIndex.Y);
                    float z = libmyo.event_get_orientation(evt, libmyo.OrientationIndex.Z);
                    float w = libmyo.event_get_orientation(evt, libmyo.OrientationIndex.W);
                    Quaternion orientation = new Quaternion(x, y, z, w);
                    this.OrientationData(this, new OrientationDataEventArgs(this, timestamp, orientation));
                    return;
                }
                case libmyo.EventType.Pose:
                    if (this.PoseChange != null)
                    {
                        Pose pose = (Pose) libmyo.event_get_pose(evt);
                        this.PoseChange(this, new PoseEventArgs(this, timestamp, pose));
                    }
                    break;

                default:
                    return;
            }
        }

        internal void SaveTrainingProfile()
        {
            libmyo.training_store_profile(this._handle, IntPtr.Zero, IntPtr.Zero);
        }

        internal void Train()
        {
            this.TrainingData.Train();
        }

        public void Vibrate(Thalmic.Myo.VibrationType type)
        {
            libmyo.vibrate(this._handle, (libmyo.VibrationType) type, new IntPtr());
        }

        internal IntPtr Handle
        {
            get
            {
                return this._handle;
            }
        }

        internal Thalmic.Myo.Hub Hub
        {
            get
            {
                return this._hub;
            }
        }

        public ulong MacAddress
        {
            get
            {
                return libmyo.get_mac_address(this._handle);
            }
        }

        internal Thalmic.Myo.TrainingData TrainingData
        {
            get
            {
                if (this._trainingData == null)
                {
                    this._trainingData = new Thalmic.Myo.TrainingData(this);
                }
                return this._trainingData;
            }
        }
    }
}

