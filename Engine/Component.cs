using System;

namespace Engine {

  public class Component {

    // contructors

    public Component(string name) {
      this.name = name;
    }

    // events

    public virtual void Attached(Actor actor) {
    }

    public virtual void Update(Actor actor, float deltaTime) {
    }

    public virtual void Draw(Actor actor, Graphics graphics) {
    }

    // data

    public string name;

  }

}