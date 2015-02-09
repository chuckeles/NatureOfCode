using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Engine {

  public class Graphics {

    // constructors

    public Graphics(string title, uint width = 800, uint height = 600) {
      window = new RenderWindow(new VideoMode(width, height), title);
      window.SetFramerateLimit(120);

      window.Closed += (object sender, EventArgs e) => {
        window.Close();
      };
      window.KeyPressed += (object sender, KeyEventArgs e) => {
        if (e.Code == Keyboard.Key.Escape)
          window.Close();
      };

      font = new Font("Resources/Font/Anonymous Pro.ttf");
      fps = new Text("", font, 14);
      fps.Position = new Vector2f(20f, 20f);
      fps.Color = Color.White;
    }

    // update

    public void Update(float deltaTime) {
      window.DispatchEvents();
      window.Clear();

      fps.DisplayedString = "" + (int)(1 / deltaTime);
    }

    // render

    public void Draw(Drawable drawable) {
      window.Draw(drawable);
    }

    public void Display() {
      Draw(fps);
      window.Display();
    }

    // getters

    public bool Open {
      get {
        return window.IsOpen();
      }
    }

    public Vector Bounds {
      get {
        return new Vector(window.Size.X, window.Size.Y);
      }
    }

    public Vector Center {
      get {
        return Bounds / 2f;
      }
    }

    public Vector GetMousePosition() {
      return new Vector(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
    }

    // data

    public RenderWindow window;
    public Font font;
    public Text fps;

  }

}