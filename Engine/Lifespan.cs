namespace Engine {

  public class Lifespan
    : Component {

    // constructors

    public Lifespan(float time)
      : base("Lifespan") {
      this.time = time;
    }

    public override void Update(Actor actor, float deltaTime) {
      time -= deltaTime;
    }

    public bool Alive {
      get {
        return time > 0f;
      }
    }

    public bool Dead {
      get {
        return !Alive;
      }
    }

    // data

    public float time;

  }

}