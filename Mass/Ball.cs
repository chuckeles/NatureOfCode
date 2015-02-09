using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Mass {

  public class Ball {

    public Ball()
      : this(new Vector(), 1f) {
    }

    public Ball(Vector position, float mass) {
      this.position = position;
      this.mass = mass;

      this.motion = new Vector();
      this.acceleration = new Vector();

      shape = new CircleShape(mass * 5f);
      shape.Origin = new Vector2f(mass * 5f, mass * 5f);
      Color color = new Color(Color.Blue);
      color.A = 150;
      shape.FillColor = color;
    }

    public void ApplyForce(Vector force) {
      acceleration += force / mass;
    }

    public void Update(Vector screen) {
      motion += acceleration;
      position += motion;

      acceleration.Reset();

      if (position.y + shape.Radius > screen.y) {
        position.y = screen.y - shape.Radius;
        motion.y *= -1;
      }

      if (position.x - shape.Radius < 0) {
        position.x = shape.Radius;
        motion.x *= -1;
      }

      if (position.x + shape.Radius > screen.x) {
        position.x = screen.x - shape.Radius;
        motion.x *= -1;
      }
    }

    public void Draw(RenderWindow window) {
      shape.Position = new Vector2f(position.x, position.y);
      window.Draw(shape);
    }

    public Vector Motion {
      get {
        return motion;
      }
    }

    public Vector Acceleration {
      get {
        return acceleration;
      }
    }

    public Vector position;
    public float mass;

    private Vector motion;
    private Vector acceleration;

    private CircleShape shape;

  }

}