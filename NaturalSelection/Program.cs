using Engine;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections;

namespace NaturalSelection {

  public class Program {

    public static void Main() {

      Graphics graphics = new Graphics("Natural Selection");
      State state = new State(graphics);

      Random random = new Random();

      uint number = 500;
      string target = "The text has Evolved!!!";
      float mutationChance = .005f;

      ArrayList pool = new ArrayList();
      for (uint i = 0; i < number; ++i)
        pool.Add(new Dna((uint)target.Length, random));

      state.Start();

      float length = target.Length * 9f;
      float xNumber = graphics.window.Size.X / length - 1;

      for (int i = 0; i < number; ++i) {
        Dna dna = (Dna)pool[i];

        Actor actor = new Actor();
        actor.AddComponent(new Engine.Transform(new Vector(length / 4 * 3 + (int)(i % xNumber) * length, 20f + (int)(i / xNumber) * 20f)));
        actor.AddComponent(new DnaDrawer(dna));

        state.Add(actor);
      }

      graphics.fps.Color = Color.Red;

      uint generation = 0;
      Text genText = new Text("", graphics.font, 20);
      genText.Position = new Vector2f(20f, graphics.Bounds.y - 50f);
      genText.Color = new Color(50, 200, 50);

      while (graphics.Open) {
        state.Update();

        genText.DisplayedString = "Generation: " + generation;
        graphics.Draw(genText);

        uint generate = 0;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) || Keyboard.IsKeyPressed(Keyboard.Key.A)) {
          ++generate;
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.S)) {
          generate += 100;
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.D)) {
          generate += 1000;
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.F)) {
          generate += 5000;
        }

        if (generate > 0) {
          for (uint g = 0; g < generate; ++g) {
            ArrayList matingPool = new ArrayList();

            foreach (Dna dna in pool)
              matingPool.Add(new DnaFitness(dna, dna.Fitness(target)));

            pool.Clear();

            double fitnessTotal = 0f;
            foreach (DnaFitness df in matingPool)
              fitnessTotal += df.fitness;
            foreach (DnaFitness df in matingPool)
              df.fitness /= fitnessTotal;

            for (uint i = 0; i < number; ++i) {
              int p1 = random.Next(0, matingPool.Count);
              int p2;
              do {
                p2 = random.Next(0, matingPool.Count);
              } while (p1 == p2);

              Dna dna1 = null;
              Dna dna2 = null;

              double total = 0;
              double r = random.NextDouble();

              foreach (DnaFitness df in matingPool) {
                if (r > total && r < total + df.fitness) {
                  dna1 = df.dna;
                  break;
                }

                total += df.fitness;
              }

              total = 0;
              r = random.NextDouble();

              foreach (DnaFitness df in matingPool) {
                if (r > total && r < total + df.fitness) {
                  dna2 = df.dna;
                  break;
                }

                total += df.fitness;
              }

              Dna child = Dna.Crossover(dna1, dna2, random);
              child.Mutate(mutationChance, random);

              pool.Add(child);
            }

            for (int i = 0; i < number; ++i)
              ((DnaDrawer)((Actor)state.actors[i])["DnaDrawer"]).dna = (Dna)pool[i];

            ++generation;
          }
        }

        state.Draw();
      }
      state.End();

    }

  }

}