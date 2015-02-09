using SFML;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics;

namespace Motion {

  public class Ball {

    public Vector2f position;
    public Vector2f motion;
    public Vector2f acceleration;

    private CircleShape shape;

    public Ball(float x, float y) {
      position = new Vector2f(x, y);

      shape = new CircleShape(10f);
      shape.Origin = new Vector2f(5f, 5f);
      shape.Position = position;
      shape.FillColor = Color.Red;
    }

    public void Update(Vector2f target) {
      acceleration = target - position;
      float length = (float)Math.Sqrt(Math.Pow(acceleration.X, 2) + Math.Pow(acceleration.Y, 2));

      acceleration.X /= length;
      acceleration.Y /= length;

      float speed = 0.0004f;

      acceleration *= speed;

      motion += acceleration;
      position += motion;
    }

    public void Draw(RenderWindow window) {
      shape.Position = position;
      window.Draw(shape);
    }

  }

}