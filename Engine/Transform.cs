namespace Engine {

  public class Transform
    : Component {

    // constructors

    public Transform(float x = 0f, float y = 0f, float r = 0f)
      : this(new Vector(x, y), r) {
    }

    public Transform(Vector position, float r = 0f)
      : base("Transform") {
      this.position = new Vector(position);
      rotation = r;
    }

    // x, y, rotation

    public float X {
      get {
        return position.x;
      }
      set {
        position.x = value;
      }
    }

    public float Y {
      get {
        return position.y;
      }
      set {
        position.y = value;
      }
    }

    public float R {
      get {
        return rotation;
      }
      set {
        rotation = value;
      }
    }

    // data

    public Vector position;
    public float rotation;

  }

}