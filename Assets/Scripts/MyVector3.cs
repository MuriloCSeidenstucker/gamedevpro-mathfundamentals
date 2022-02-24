using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyVector3
{
    public float X;
    public float Y;
    public float Z;

    public MyVector3(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public float Magnitude => Mathf.Sqrt((X*X)+(Y*Y)+(Z*Z));

    public MyVector3 Normalize
    {
        get
        {
            var u = new MyVector3(0,0,0);
            u.X = this.X * (1/this.Magnitude);
            u.Y = this.Y * (1/this.Magnitude);
            u.Z = this.Z * (1/this.Magnitude);
            return u;
        }
    }

    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
        => new MyVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    public static MyVector3 operator *(MyVector3 a, float d)
        => new MyVector3(a.X * d, a.Y * d, a.Z * d);
}
