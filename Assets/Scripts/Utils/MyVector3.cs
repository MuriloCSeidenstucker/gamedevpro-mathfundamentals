using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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

    public static implicit operator Vector3(MyVector3 v) => new Vector3(v.X, v.Y, v.Z);
    public static explicit operator MyVector3(Vector3 v) => new MyVector3(v.x, v.y, v.z);

    public static MyVector3 Right => new MyVector3(1, 0, 0);
    public static MyVector3 Up => new MyVector3(0, 1, 0);
    public static MyVector3 Forward => new MyVector3(0, 0, 1);
    public static MyVector3 One => new MyVector3(1, 1, 1);
    public static MyVector3 Zero => new MyVector3(0, 0, 0);

    public float Magnitude => Mathf.Sqrt(SqrMagnitude);
    public float SqrMagnitude => (X*X)+(Y*Y)+(Z*Z);

    public MyVector3 Normalize => this * (1.0f/Magnitude);

    public static MyVector3 operator -(MyVector3 a)
        => new MyVector3(-a.X, -a.Y, -a.Z);
    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
        => new MyVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    public static MyVector3 operator *(MyVector3 a, float d)
        => new MyVector3(a.X * d, a.Y * d, a.Z * d);
}
