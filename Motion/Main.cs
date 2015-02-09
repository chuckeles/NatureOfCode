using SFML;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics;

namespace Motion {

  public class Program {

    public static void Main() {

      RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Motion");
      Vector2f center = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

      Random random = new Random();

      uint ballNumber = 10;
      Ball[] balls = new Ball[ballNumber];
      for (uint i = 0; i < ballNumber; ++i)
        balls[i] = new Ball(center.X + ((float)random.NextDouble() * 2f - 1f) * 200f, center.Y + ((float)random.NextDouble() * 2f - 1f) * 200f);

      window.Closed += (object sender, EventArgs e) => {
        window.Close();
      };

      window.KeyPressed += (object sender, KeyEventArgs e) => {
        if (e.Code == Keyboard.Key.Escape)
          window.Close();
        else if (e.Code == Keyboard.Key.R) {
          foreach (Ball ball in balls) {
            ball.position.X = center.X + ((float)random.NextDouble() * 2f - 1f) * 200f;
            ball.position.Y = center.Y + ((float)random.NextDouble() * 2f - 1f) * 200f;

            ball.motion = new Vector2f();
            ball.acceleration = new Vector2f();
          }
        }
      };

      while (window.IsOpen()) {

        window.Clear();
        window.DispatchEvents();

        Vector2f mouse = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);

        foreach (Ball ball in balls) {
          ball.Update(mouse);
          ball.Draw(window);
        }

        window.Display();
      }

    }

  }

}