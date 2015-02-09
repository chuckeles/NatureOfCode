namespace Engine {

  public class Motion
    : Component {

    // constructors

    public Motion()
      : base("Motion") {
      motion = new Vector();
      acceleration = new Vector();

      angularMotion = 0f;
      angularAcceleration = 0f;
    }

    // events

    public override void Attached(Actor actor) {
      if (!actor.HasComponent("Transform"))
        actor.AddComponent(new Transform());

      this.actor = actor;
    }

    public override void Update(Actor actor, float deltaTime) {
      Transform transform = (Transform)actor["Transform"];

      motion += acceleration;
      transform.position += motion;

      angularMotion += angularAcceleration;
      transform.R += angularMotion;

      acceleration.Reset();
      angularAcceleration = 0f;
    }

    // force

    public void ApplyForce(Vector force) {
      float mass = 1f;

      if (actor.HasComponent("Mass"))
        mass = ((Mass)actor["Mass"]).mass;

      acceleration += force / mass;
    }

    public void ApplyAngularForce(float force) {
      float mass = 1f;

      if (actor.HasComponent("Mass"))
        mass = ((Mass)actor["Mass"]).mass;

      angularAcceleration += force / mass;
    }

    // data

    public Vector motion;
    public Vector acceleration;

    public float angularMotion;
    public float angularAcceleration;

    private Actor actor;

  }

}