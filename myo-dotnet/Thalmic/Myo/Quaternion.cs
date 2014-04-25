namespace Thalmic.Myo
{
    using System;

    public class Quaternion
    {
        private readonly float _w;
        private readonly float _x;
        private readonly float _y;
        private readonly float _z;

        public Quaternion() : this(0f, 0f, 0f, 1f)
        {
        }

        public Quaternion(float x, float y, float z, float w)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._w = w;
        }

        public float Magnitude()
        {
            return (float) Math.Sqrt((double) ((((this._w * this._w) + (this._x * this._x)) + (this._y * this._y)) + (this._z * this._z)));
        }

        public static Quaternion Normalize(Quaternion quat)
        {
            return (Quaternion) (quat / quat.Magnitude());
        }

        public static Quaternion operator +(Quaternion quat1, Quaternion quat2)
        {
            return new Quaternion(quat1._x + quat2._x, quat1._y + quat2._y, quat1._z + quat2._z, quat1._w + quat2._w);
        }

        public static Quaternion operator /(Quaternion quat, float scalar)
        {
            return new Quaternion(quat._x / scalar, quat._y / scalar, quat._z / scalar, quat._w / scalar);
        }

        public static Quaternion operator *(float scalar, Quaternion quat)
        {
            return (Quaternion) (quat * scalar);
        }

        public static Quaternion operator *(Quaternion quat, float scalar)
        {
            return new Quaternion(quat._x * scalar, quat._y * scalar, quat._z * scalar, quat._w * scalar);
        }

        public static Vector3 operator *(Quaternion quat, Vector3 vec)
        {
            float num = quat.X * 2f;
            float num2 = quat.Y * 2f;
            float num3 = quat.Z * 2f;
            float num4 = quat.X * num;
            float num5 = quat.Y * num2;
            float num6 = quat.Z * num3;
            float num7 = quat.X * num2;
            float num8 = quat.X * num3;
            float num9 = quat.Y * num3;
            float num10 = quat.W * num;
            float num11 = quat.W * num2;
            float num12 = quat.W * num3;
            float x = (((1f - (num5 + num6)) * vec.X) + ((num7 - num12) * vec.Y)) + ((num8 + num11) * vec.Z);
            float y = (((num7 + num12) * vec.X) + ((1f - (num4 + num6)) * vec.Y)) + ((num9 - num10) * vec.Z);
            return new Vector3(x, y, (((num8 - num11) * vec.X) + ((num9 + num10) * vec.Y)) + ((1f - (num4 + num5)) * vec.Z));
        }

        public static Quaternion operator -(Quaternion quat1, Quaternion quat2)
        {
            return (quat1 + -quat2);
        }

        public static Quaternion operator -(Quaternion quat)
        {
            return new Quaternion(-quat._x, -quat._y, -quat._z, -quat._w);
        }

        public static float Pitch(Quaternion quat)
        {
            return (float) Math.Asin((double) (2f * ((quat._w * quat._y) - (quat._z * quat._x))));
        }

        public static float Roll(Quaternion quat)
        {
            return (float) Math.Atan2((double) (2f * ((quat._w * quat._x) + (quat._y * quat._z))), (double) (1f - (2f * ((quat._x * quat._x) + (quat._y * quat._y)))));
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", new object[] { this.X, this.Y, this.Z, this.W });
        }

        public static float Yaw(Quaternion quat)
        {
            return (float) Math.Atan2((double) (2f * ((quat._w * quat._z) + (quat._x * quat._y))), (double) (1f - (2f * ((quat._y * quat._y) + (quat._z * quat._z)))));
        }

        public float W
        {
            get
            {
                return this._w;
            }
        }

        public float X
        {
            get
            {
                return this._x;
            }
        }

        public float Y
        {
            get
            {
                return this._y;
            }
        }

        public float Z
        {
            get
            {
                return this._z;
            }
        }
    }
}

