using Engine;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics;

namespace Planets {

  public class Program {

    public static Actor NewPlanet(Vector position, Color color, float mass, float radius) {
      Actor planet = new Actor();

      planet.AddComponent(new Engine.Transform(position));
      planet.AddComponent(new Mass(mass));
      planet.AddComponent(new Motion());
      Circle spr = new Circle(radius);
      spr.Color = color;
      planet.AddComponent(spr);

      return planet;
    }

    public static void Main() {

      Graphics graphics = new Graphics("Planets");
      Random random = new Random();

      uint number = 20;
      Actor[] planets = new Actor[number];
      for (uint i = 0; i < number; ++i) {
        float mass = (float)random.NextDouble() * 20f + 5f;
        planets[i] = NewPlanet(
          graphics.Center + Vector.MakeRandom(random) * 400f,
          new Color((byte)random.Next(100, 250), (byte)random.Next(100, 250), (byte)random.Next(100, 250), 200),
          mass,
          mass * 2f
        );
      }

      Stopwatch clock = Stopwatch.StartNew();

      while (graphics.Open) {
        float deltaTime = clock.ElapsedMilliseconds / 1000f;
        clock.Restart();

        graphics.Update(deltaTime);

        foreach (Actor planet in planets) {
          Vector force = new Vector();

          foreach (Actor other in planets) {
            if (other == planet)
              continue;

            float G = .6f;

            force = ((Engine.Transform)planet["Transform"]).position - ((Engine.Transform)other["Transform"]).position;
            float distance = force.Length;
            if (distance < 20f)
              distance = 20f;
            force.Normalize();
            float strength = (G * ((Mass)planet["Mass"]).mass * ((Mass)other["Mass"]).mass) / (distance * distance);

            force *= strength;
            ((Motion)other["Motion"]).ApplyForce(force);
          }

          planet.Update(deltaTime);
        }

        foreach (Actor planet in planets)
          planet.Draw(graphics);

        graphics.Display();
      }

    }

  }

}