using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Walker {

  public class Program {

    public static void Main() {

      RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Random Walker");
      Walker walker = new Walker(window.Size.X / 2f, window.Size.Y / 2f);

      window.Closed += (object sender, EventArgs e) => {
        window.Close();
      };

      window.KeyPressed += (object sender, KeyEventArgs e) => {
        if (e.Code == Keyboard.Key.Escape)
          window.Close();
      };

      while (window.IsOpen()) {
        window.DispatchEvents();

        walker.Step();
        walker.Draw(window);

        window.Display();
      }

    }

  }

}