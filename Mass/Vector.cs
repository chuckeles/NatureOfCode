using System;

namespace Mass {

  public class Vector {

    public Vector()
      : this(0f, 0f) {
    }

    public Vector(float x, float y) {
      this.x = x;
      this.y = y;
    }

    public Vector(Vector other) {
      this.x = other.x;
      this.y = other.y;
    }

    public void Reset() {
      x = 0;
      y = 0;
    }

    public void Normalize() {
      if (x == 0f && y == 0f)
        return;

      float length = Length;

      x /= length;
      y /= length;
    }

    public float Length {
      get {
        return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
      }
    }

    public static Vector operator +(Vector one, Vector two) {
      Vector res = new Vector();

      res.x = one.x + two.x;
      res.y = one.y + two.y;

      return res;
    }

    public static Vector operator +(Vector one, float two) {
      Vector res = new Vector();

      res.x = one.x + two;
      res.y = one.y + two;

      return res;
    }

    public static Vector operator -(Vector one, Vector two) {
      Vector res = new Vector();

      res.x = one.x - two.x;
      res.y = one.y - two.y;

      return res;
    }

    public static Vector operator -(Vector one, float two) {
      Vector res = new Vector();

      res.x = one.x - two;
      res.y = one.y - two;

      return res;
    }

    public static Vector operator *(Vector one, Vector two) {
      Vector res = new Vector();

      res.x = one.x * two.x;
      res.y = one.y * two.y;

      return res;
    }

    public static Vector operator *(Vector one, float two) {
      Vector res = new Vector();

      res.x = one.x * two;
      res.y = one.y * two;

      return res;
    }

    public static Vector operator /(Vector one, Vector two) {
      Vector res = new Vector();

      res.x = one.x / two.x;
      res.y = one.y / two.y;

      return res;
    }

    public static Vector operator /(Vector one, float two) {
      Vector res = new Vector();

      res.x = one.x / two;
      res.y = one.y / two;

      return res;
    }

    public float x;
    public float y;

  }

}