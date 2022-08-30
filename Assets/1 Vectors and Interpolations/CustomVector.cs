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

    #region"Metodos de la clase"
    /// <summary>
    /// Dibuja en la vista de Scene el vector
    /// </summary>
    public void Draw()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), Color.red);
    }

    /// <summary>
    /// Dibuja en la vista de Scene el vector con un color especificado
    /// </summary>
    /// <param name="color">El color con el que se quiere representar el vector</param>
    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }

    /// <summary>
    /// Dibuja en la vida se Scene el vector con base en otro origen distinto del origen del mundo
    /// </summary>
    /// <param name="origin">El vector con el que se reemplazará el origen</param>
    public void Draw(CustomVector2 origin)
    {
        Debug.DrawLine(origin, this + origin);
    }

    /// <summary>
    /// Dibuja en la vida se Scene el vector con base en otro origen distinto del origen del mundo especificando un color con el que representar el vector
    /// </summary>
    /// <param name="origin">El color con el que se quiere representar el vector</param>
    /// <param name="color">El vector con el que se reemplazará el origen</param>
    public void Draw(CustomVector2 origin, Color color)
    {
        Debug.DrawLine(origin, this + origin, color);
    }

    public static CustomVector2 Lerp(CustomVector2 vector1, CustomVector2 vector2, float factor)
    {
        return vector1 + (vector2 - vector1) * factor;       
    }

    public float Magnitude()
    {
        return Mathf.Sqrt((this.x * this.x) + (this.y * this.y));
    }

    public void Normalized()
    {
        if (magnitude < float.Epsilon) this = new CustomVector2(0, 0);
        this = this * (1/this.magnitude);
    }
    #endregion

    #region"Propiedades"

    public float magnitude { get => Mathf.Sqrt((this.x * this.x) + (this.y * this.y)); }

    public Vector2 normalized 
    {
        get
        {
            if (magnitude < float.Epsilon) return new CustomVector2(0, 0);
            return this * (1 / this.magnitude);
        }
    }

    #endregion

    #region"Operadores"
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
    #endregion

    #region"Convertores implicitos"
    public static implicit operator Vector2(CustomVector2 a)
    {
        return new Vector2(a.x, a.y);
    }

    public static implicit operator Vector3(CustomVector2 a)
    {
        return new Vector3(a.x, a.y, 0);
    } 

    public static implicit operator CustomVector2(Vector3 a)
    {
        return new CustomVector2(a.x, a.y);
    }

    public static implicit operator CustomVector2(Vector2 a)
    {
        return new CustomVector2(a.x, a.y);
    }
    #endregion
}
