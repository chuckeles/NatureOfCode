namespace Engine {

  public class Health
    : Component {

    // constructors

    public Health(float health = 1f)
      : base("Health") {
      this.health = health;
    }

    // getters

    public bool Alive {
      get {
        return health > 0f;
      }
    }

    public bool Dead {
      get {
        return !Alive;
      }
    }

    // data

    public float health;

  }

}