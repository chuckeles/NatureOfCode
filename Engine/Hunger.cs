namespace Engine {

  public class Hunger
    : Component {

    // constructors

    public Hunger(float hunger = 0f)
      : base("Hunger") {
      this.hunger = hunger;
    }

    public override void Update(Actor actor, float deltaTime) {
      hunger += deltaTime;
    }

    // data

    public float hunger;

  }

}