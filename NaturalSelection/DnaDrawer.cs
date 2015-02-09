using Engine;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace NaturalSelection {

  public class DnaDrawer
    : Component {

    public DnaDrawer(Dna dna)
      : base("DnaDrawer") {
      this.dna = dna;

      text = new Text();
      text.CharacterSize = 14;
      text.Color = new Color(250, 250, 250, 150);
    }

    public override void Attached(Actor actor) {
      if (!actor.HasComponent("Transform"))
        actor.AddComponent(new Engine.Transform());
    }

    public override void Draw(Actor actor, Graphics graphics) {
      text.Font = graphics.font;
      text.DisplayedString = new string(dna.text, 0, (int)dna.length);

      FloatRect bounds = text.GetLocalBounds();
      text.Origin = new Vector2f(bounds.Width / 2, bounds.Height / 2);

      text.Position = new Vector2f(((Engine.Transform)actor["Transform"]).position.x, ((Engine.Transform)actor["Transform"]).position.y);
      graphics.Draw(text);
    }

    public Dna dna;
    public Text text;

  }

}