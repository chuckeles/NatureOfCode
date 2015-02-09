using System;
using System.Collections;

namespace Engine {

  public class HungryCreature
    : Component {

    // constructors

    public HungryCreature(float speed = 2f)
      : base("Creature") {
      clock = new Clock();
      random = new Random();
      target = new Vector();

      maxSpeed = speed;
      wanderSpeed = speed / 3;
    }

    // events

    public override void Attached(Actor actor) {
      if (!actor.HasComponent("Transform"))
        actor.AddComponent(new Transform());
      if (!actor.HasComponent("Motion"))
        actor.AddComponent(new Motion());

      target = new Vector(((Transform)actor["Transform"]).position);
      clock.Restart();
    }

    public override void Update(Actor actor, float deltaTime) {
      bool hasHealth = actor.HasComponent("Health");
      bool hasHunger = actor.HasComponent("Hunger");
      bool panic = false;

      if (clock.Elapsed > 3f) {
        clock.Restart();

        target += Vector.MakeRandom(random) * 50f + 20f;
      }

      if (hasHealth) {
        if (((Health)actor["Health"]).Dead)
          State.current.Remove(actor);
      }

      if (hasHunger) {
        if (hasHealth) {
          if (((Hunger)actor["Hunger"]).hunger > 20f)
            ((Health)actor["Health"]).health -= 5f * deltaTime;
        }

        if (((Hunger)actor["Hunger"]).hunger > 7f) {
          panic = true;

          if (food == null) {
            ArrayList actors = State.current.actors;

            foreach (Actor a in actors) {
              if (!a.HasComponent("Food"))
                continue;

              if (food == null ||
                (((Transform)a["Transform"]).position - ((Transform)actor["Transform"]).position).Length < (((Transform)food["Transform"]).position - ((Transform)actor["Transform"]).position).Length)
                food = a;
            }
          }
          else {
            target = ((Transform)food["Transform"]).position;

            if ((((Transform)food["Transform"]).position - ((Transform)actor["Transform"]).position).Length < 10f) {
              ((Hunger)actor["Hunger"]).hunger -= 10f;

              State.current.Remove(food);
              food = null;
              panic = false;
            }
          }
        }
      }

      Vector desired = target - ((Transform)actor["Transform"]).position;
      float distance = desired.Length;
      desired.Normalize();
      desired *= panic ? maxSpeed : wanderSpeed;

      float closeDistance = 40f;
      if (distance < closeDistance)
        desired *= distance / closeDistance;

      Vector force = desired - ((Motion)actor["Motion"]).motion;

      if (force.Length > .1f)
        force.Length = .03f;

      ((Motion)actor["Motion"]).ApplyForce(force);
      ((Transform)actor["Transform"]).rotation = ((Motion)actor["Motion"]).motion.Angle();
    }

    // data

    public float maxSpeed;
    public float wanderSpeed;

    private Clock clock;
    private Random random;

    private Vector target;
    private Actor food;

  }

}