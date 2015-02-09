using System;

namespace Engine {

  // 2D vector
  public class Vector {

    // constructors

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

    // math

    public static Vector MakeRandom(Random random) {
      Vector res = new Vector();

      res.x = (float)random.NextDouble() * 2f - 1f;
      res.y = (float)random.NextDouble() * 2f - 1f;

      return res;
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
      set {
        this.Normalize();
        this.x *= value; ;
        this.y *= value;
      }
    }

    public float Angle() {
      if (Math.Abs(x) < 0.0001f)
        return y > 0f ? (float)Math.PI / 2f : (float)Math.PI * 3f / 2f;
      else
        return (float)Math.Atan2(y, x);
    }

    // operators

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

    // data

    public float x;
    public float y;

  }

}