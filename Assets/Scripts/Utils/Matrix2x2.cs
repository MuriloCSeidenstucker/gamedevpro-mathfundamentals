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

    public static Vector2 VectorMultiplier(Matrix2x2 m, Vector2 v)
    {
        return new Vector2((m.IX*v.x) + (m.JX*v.y), (m.IY*v.x) + (m.JY*v.y));
    }

    public static Vector2 MatrixMultiplier(Matrix2x2[] m, Vector2 v, out Matrix2x2 mR)
    {
        mR = Matrix2x2.Identity;
        if (m.Length > 0)
        {
            for (int i = 0; i < m.Length; i++)
            {
                var cM = m[i];
                var a = (cM.IX*mR.IX) + (cM.JX*mR.IY);
                var b = (cM.IY*mR.IX) + (cM.JY*mR.IY);
                var c = (cM.IX*mR.JX) + (cM.JX*mR.JY);
                var d = (cM.IY*mR.JX) + (cM.JY*mR.JY);
                mR = new Matrix2x2(a, b, c, d);
            }
        }
        return VectorMultiplier(mR, v);
    }
}
