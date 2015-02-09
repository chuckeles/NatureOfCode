using Engine;
using SFML;
using SFML.Graphics;

namespace Agents {

  public class MainState
    : State {

    public MainState(Graphics graphics)
      : base(graphics) {
    }

    public override void Start() {
      base.Start();

      AddCreature(graphics.Center);

      graphics.window.MouseButtonPressed += (object sender, SFML.Window.MouseButtonEventArgs e) => {
        AddFood(new Vector(e.X, e.Y));
      };
    }

    public Actor AddCreature(Vector position) {
      Actor creature = new Actor();
      creature.AddComponent(new Engine.Transform(position));
      creature.AddComponent(new Motion());
      creature.AddComponent(new Square(20f));
      ((Square)creature["Square"]).Color = new Color(50, 250, 100, 200);
      creature.AddComponent(new Health());
      creature.AddComponent(new Hunger());
      creature.AddComponent(new HungryCreature());

      actors.Add(creature);

      return creature;
    }

    public Actor AddFood(Vector position) {
      Actor food = new Actor();
      food.AddComponent(new Engine.Transform(position));
      food.AddComponent(new Motion());
      food.AddComponent(new Circle(5f));
      ((Circle)food["Circle"]).Color = new Color(250, 50, 0, 200);
      food.AddComponent(new Food());

      actors.Add(food);

      return food;
    }

  }

}