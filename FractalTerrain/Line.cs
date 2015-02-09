using Engine;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace FractalTerrain {

  public class Line {

    public Line(Vector from, Vector to) {
      this.from = from;
      this.to = to;

      shape = new RectangleShape();
      shape.Position = new Vector2f(from.x, from.y);
      shape.FillColor = Color.White;

      Update();
    }

    public Vector From {
      get {
        return from;
      }
      set {
        from = value;
        Update();
      }
    }

    public Vector To {
      get {
        return to;
      }
      set {
        to = value;
        Update();
      }
    }

    private void Update() {
      shape.Size = new Vector2f((to - from).Length, 2f);
      shape.Rotation = (to - from).Angle() / (float)Math.PI * 180f;
    }

    private Vector from;
    private Vector to;

    public RectangleShape shape;

  }

}