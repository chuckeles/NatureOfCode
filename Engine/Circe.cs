using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Engine {

  public class Circle
    : Component {

    // constructors

    public Circle(float radius = 10f)
      : base("Circle") {
      sprite = new CircleShape(radius);
      sprite.Origin = new Vector2f(radius, radius);
    }

    // color

    public Color Color {
      get {
        return sprite.FillColor;
      }
      set {
        sprite.FillColor = value;
      }
    }

    // events

    public override void Attached(Actor actor) {
      if (!actor.HasComponent("Transform"))
        actor.AddComponent(new Transform());
    }

    public override void Draw(Actor actor, Graphics graphics) {
      Transform position = (Transform)actor["Transform"];
      sprite.Position = new Vector2f(position.X, position.Y);

      graphics.Draw(sprite);
    }

    // data

    private CircleShape sprite;

  }

}