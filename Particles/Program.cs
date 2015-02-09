using Engine;
using System;

namespace Particles {

  public class Program {

    public static void Main() {

      Graphics graphics = new Graphics("Particles");
      Clock clock = new Clock();

      Random random = new Random();

      EmitterInfo info = new EmitterInfo();
      info.lifeSpan = 2f;
      info.interval = .02f;
      info.spawnParticles = 2;
      info.color = new SFML.Graphics.Color((byte)random.Next(100, 250), (byte)random.Next(100, 250), (byte)random.Next(100, 250), 200);
      info.minEmission = new Vector(-.5f, -.5f);
      info.maxEmission = new Vector(.5f, -2f);

      Actor emitter = new Actor();
      emitter.AddComponent(new Transform(graphics.Center));
      emitter.AddComponent(new Emitter(info));

      Vector gravity = new Vector(0f, .01f);

      while (graphics.Open) {
        float deltaTime = clock.Restart();

        graphics.Update(deltaTime);

        ((Emitter)emitter["Emitter"]).ApplyForce(gravity);
        ((Transform)emitter["Transform"]).position = new Vector(graphics.GetMousePosition());
        emitter.Update(deltaTime);
        emitter.Draw(graphics);

        graphics.Display();
      }

    }

  }

}