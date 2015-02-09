using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Engine {

  public class Square
    : Component {

    // constructors

    public Square(float size = 10f)
      : base("Square") {
      sprite = new RectangleShape(new Vector2f(size, size));
      sprite.Origin = new Vector2f(size / 2f, size / 2f);
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
      sprite.Rotation = position.R / (float)Math.PI * 180f;

      graphics.Draw(sprite);
    }

    // data

    private RectangleShape sprite;

  }

}