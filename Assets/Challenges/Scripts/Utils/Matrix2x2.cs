using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Matrix2x2
{
    // First column.
    public float IX;
    public float IY;
    // Second column.
    public float JX;
    public float JY;

    public Matrix2x2(float iX, float iY, float jX, float jY)
    {
        IX = iX;
        IY = iY;
        JX = jX;
        JY = jY;
    }

    public static Matrix2x2 Identity => new Matrix2x2(1, 0, 0, 1);

    public static Vector2 operator *(Matrix2x2 m, Vector2 v)
        => new Vector2((m.IX*v.x) + (m.JX*v.y), (m.IY*v.x) + (m.JY*v.y));

    public static Vector2 operator *(Vector2 v, Matrix2x2 m)
        => m * v;

    public static Matrix2x2 operator *(in Matrix2x2 m1, in Matrix2x2 m2)
    {
        var result = new Matrix2x2();
        result.IX = (m2.IX*m1.IX) + (m2.JX*m1.IY);
        result.IY = (m2.IY*m1.IX) + (m2.JY*m1.IY);
        result.JX = (m2.IX*m1.JX) + (m2.JX*m1.JY);
        result.JY = (m2.IY*m1.JX) + (m2.JY*m1.JY);
        return result;
    }
}
