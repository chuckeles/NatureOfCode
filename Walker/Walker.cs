using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Walker {

  public class Walker {

    public float x;
    public float y;

    private Random random;
    private RectangleShape dot;

    public Walker(float x, float y) {
      this.x = x;
      this.y = y;

      random = new Random();
      dot = new RectangleShape(new Vector2f(1f, 1f));
      dot.Position = new Vector2f(x, y);
      dot.FillColor = Color.White;
    }

    public void Step() {
      x += (float)random.NextDouble() * 2f - 1f;
      y += (float)random.NextDouble() * 2f - 1f;

      dot.Position = new Vector2f(x, y);
    }

    public void Draw(RenderWindow window) {
      window.Draw(dot);
    }

  }

}