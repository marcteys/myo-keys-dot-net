namespace Thalmic.Myo
{
    using System;
    using System.Reflection;

    public class Vector3
    {
        private readonly float[] _data;

        public Vector3() : this(0f, 0f, 0f)
        {
        }

        public Vector3(float x, float y, float z)
        {
            this._data = new float[] { x, y, z };
        }

        public float Magnitude()
        {
            return (float) Math.Sqrt((double) (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)));
        }

        public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        public static Vector3 operator /(Vector3 vector, float scalar)
        {
            return new Vector3(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        }

        public static Vector3 operator *(float scalar, Vector3 vector)
        {
            return (Vector3) (vector * scalar);
        }

        public static Vector3 operator *(Vector3 vector, float scalar)
        {
            return new Vector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
        {
            return (vector1 + -vector2);
        }

        public static Vector3 operator -(Vector3 vector)
        {
            return new Vector3(-vector.X, -vector.Y, -vector.Z);
        }

        public override string ToString()
        {
            return string.Format("{0,6:0.00},{1,6:0.00},{2,6:0.00}", this.X, this.Y, this.Z);
        }

        public float this[uint index]
        {
            get
            {
                return this._data[index];
            }
        }

        public float X
        {
            get
            {
                return this._data[0];
            }
        }

        public float Y
        {
            get
            {
                return this._data[1];
            }
        }

        public float Z
        {
            get
            {
                return this._data[2];
            }
        }
    }
}

