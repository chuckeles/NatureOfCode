using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Mass {

  public class Program {

    public static void Main() {

      RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Mass");
      window.SetFramerateLimit(120);

      window.Closed += (object sender, EventArgs e) => {
        window.Close();
      };
      window.KeyPressed += (object sender, KeyEventArgs e) => {
        if (e.Code == Keyboard.Key.Escape)
          window.Close();
      };

      Vector screen = new Vector(window.Size.X, window.Size.Y);
      Vector center = new Vector(window.Size.X / 2f, window.Size.Y / 2f);
      Vector gravity = new Vector(0f, 0.008f);
      Vector wind = new Vector(0.001f, 0f);

      Random random = new Random();

      uint number = 40;
      Ball[] balls = new Ball[number];
      for (uint i = 0; i < number; ++i)
        balls[i] = new Ball(center + new Vector((float)random.NextDouble() * 400f - 200f, (float)random.NextDouble() * 400f - 200f) - new Vector(100f, 0f), (float)random.NextDouble() * 6f + 1f);

      while (window.IsOpen()) {
        window.DispatchEvents();

        window.Clear();

        foreach (Ball ball in balls) {
          ball.ApplyForce(gravity * ball.mass);
          ball.ApplyForce(wind);

          Vector friction = new Vector(ball.Motion);
          float speed = friction.Length;
          friction.Normalize();

          float c = .005f;
          friction *= -c * (float)Math.Pow(speed, 2);

          ball.ApplyForce(friction);

          ball.Update(screen);
        }

        foreach (Ball ball in balls)
          ball.Draw(window);

        window.Display();
      }

    }

  }

}