using Engine;
using SFML;
using SFML.Window;
using System;
using System.Collections;

namespace FractalTerrain {

  public class Program {

    public static void Generate() {
      ArrayList toAdd = new ArrayList();
      ArrayList toRemove = new ArrayList();

      foreach (Line line in lines) {
        Vector from = line.From;
        Vector to = line.To;

        toRemove.Add(line);

        float length = (to - from).Length;
        Vector center = (to - from) / 2 + from;

        center.y += ((float)random.NextDouble() * 2 - 1) * (length / 3);

        toAdd.Add(new Line(from, center));
        toAdd.Add(new Line(center, to));
      }

      foreach (Line line in toRemove) {
        lines.Remove(line);
      }
      toRemove.Clear();

      foreach (Line line in toAdd) {
        lines.Add(line);
      }
      toAdd.Clear();

      if (lines.Count < 400)
        Generate();
    }

    public static void Main() {

      Graphics graphics = new Graphics("Fractal Terrain");
      State state = new State(graphics);

      random = new Random();

      lines = new ArrayList(256);
      lines.Add(new Line(new Vector(0f, graphics.Center.y), new Vector(graphics.Bounds.x, graphics.Center.y)));

      Generate();

      bool restart = false;
      graphics.window.KeyPressed += (object sender, KeyEventArgs e) => {
        if (e.Code == Keyboard.Key.R) {
          graphics.window.Close();
          restart = true;
        }
      };

      state.Start();
      while (graphics.Open) {
        state.Update();

        foreach (Line line in lines)
          graphics.Draw(line.shape);

        state.Draw();
      }
      state.End();

      if (restart)
        Main();

    }

    public static Random random;

    public static ArrayList lines;

  }

}