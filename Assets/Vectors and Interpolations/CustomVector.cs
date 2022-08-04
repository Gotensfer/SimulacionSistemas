using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CustomVector2
{
    public float x;
    public float y;

    public CustomVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Dibuja en la vista de Scene el vector
    /// </summary>
    public void Draw()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), Color.red);
    }

    /// <summary>
    /// Dibuja en la vista de Scene el vector pasándole como parámetro otro color
    /// </summary>
    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }

    public void Draw(CustomVector2 origin)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x, y, 0));
    }

    public void Draw(CustomVector2 origin, Color color)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x + origin.x, y + origin.y, 0), color);
    }

    public static CustomVector2 Lerp(CustomVector2 vector1, CustomVector2 vector2, float factor)
    {
        return vector1 + (vector2 - vector1) * factor;
        
    }

    public static CustomVector2 operator +(CustomVector2 a, CustomVector2 b)
    {
        return new CustomVector2(a.x + b.x, a.y + b.y);
    }

    public static CustomVector2 operator -(CustomVector2 a, CustomVector2 b)
    {
        return new CustomVector2(a.x - b.x, a.y - b.y);
    }

    public static CustomVector2 operator *(float a, CustomVector2 b)
    {
        return new CustomVector2(a * b.x, a * b.y);
    }

    public static CustomVector2 operator *(CustomVector2 a, float b)
    {
        return new CustomVector2(a.x * b, a.y * b);
    }

    public static implicit operator Vector2(CustomVector2 a)
    {
        return new Vector2(a.x, a.y);
    }

    public static implicit operator Vector3(CustomVector2 a)
    {
        return new Vector3(a.x, a.y, 0);
    } 
}
