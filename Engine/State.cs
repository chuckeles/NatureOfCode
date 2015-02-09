using System;
using System.Collections;

namespace Engine {

  public class State {

    // contructor

    public State(Graphics graphics) {
      this.graphics = graphics;
      actors = new ArrayList();
      toRemove = new ArrayList();
      clock = new Clock();
    }

    // events

    public virtual void Start() {
      clock.Restart();

      current = this;
    }

    public virtual void Update() {
      foreach (Actor actor in toRemove)
        actors.Remove(actor);
      toRemove.Clear();

      float deltaTime = clock.Restart();

      graphics.Update(deltaTime);

      foreach (Actor actor in actors)
        actor.Update(deltaTime);
    }

    public virtual void Draw() {
      foreach (Actor actor in actors)
        actor.Draw(graphics);

      graphics.Display();
    }

    public virtual void End() {
      current = null;
    }

    // actors

    public void Add(Actor actor) {
      actors.Add(actor);
    }

    public void Remove(Actor actor) {
      toRemove.Add(actor);
    }

    // data

    public Graphics graphics;
    public ArrayList actors;
    private ArrayList toRemove;

    private Clock clock;

    public static State current;

  }

}