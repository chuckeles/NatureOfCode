using SFML;
using SFML.Graphics;
using System;
using System.Collections;

namespace Engine {

  public struct EmitterInfo {
    public float lifeSpan;
    public float interval;
    public uint spawnParticles;

    public Color color;
    public Vector minEmission;
    public Vector maxEmission;
  }

  public class Emitter
    : Component {

    // constructors

    public Emitter(EmitterInfo info)
      : base("Emitter") {
      particles = new ArrayList(128);
      this.info = info;
      clock = new Clock();
      random = new Random();
    }

    // events

    public override void Update(Actor actor, float deltaTime) {
      ArrayList toRemove = new ArrayList();
      foreach (Actor p in particles) {
        p.Update(deltaTime);

        if (((Lifespan)p["Lifespan"]).Dead)
          toRemove.Add(p);
        else {
          Color newColor = new Color(((Square)p["Square"]).Color);
          newColor.A = (byte)(((Lifespan)p["Lifespan"]).time / info.lifeSpan * info.color.A);
          ((Square)p["Square"]).Color = newColor;
        }
      }

      foreach (Actor p in toRemove)
        particles.Remove(p);
      toRemove.Clear();

      if (clock.Elapsed > info.interval) {
        clock.Restart();
        for (uint i = 0; i < info.spawnParticles; ++i)
          SpawnParticle(((Transform)actor["Transform"]).position);
      }
    }

    public override void Draw(Actor actor, Graphics graphics) {
      foreach (Actor p in particles)
        p.Draw(graphics);
    }

    // particles

    public void SpawnParticle(Vector position) {
      Actor p = new Actor();
      p.AddComponent(new Transform(position));
      p.AddComponent(new Motion());
      ((Motion)p["Motion"]).motion = new Vector(
        (float)random.NextDouble() * (info.maxEmission.x - info.minEmission.x) + info.minEmission.x,
        (float)random.NextDouble() * (info.maxEmission.y - info.minEmission.y) + info.minEmission.y
        );
      ((Motion)p["Motion"]).angularMotion = (float)random.NextDouble() * 5f - 2.5f;
      p.AddComponent(new Lifespan(info.lifeSpan));
      p.AddComponent(new Square(10f));
      ((Square)p["Square"]).Color = new Color(info.color);

      particles.Add(p);
    }

    public void ApplyForce(Vector force) {
      foreach (Actor p in particles)
        ((Motion)p["Motion"]).ApplyForce(force);
    }

    // data

    private ArrayList particles;
    private EmitterInfo info;
    private Clock clock;
    private Random random;

  }

}