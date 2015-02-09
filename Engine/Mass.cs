namespace Engine {

  public class Mass
    : Component {

    // constructors

    public Mass(float mass = 1f)
      : base("Mass") {
      this.mass = mass;
    }

    // data

    public float mass;

  }

}