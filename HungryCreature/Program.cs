using Engine;
using System;

namespace Agents {

  public class Program {

    public static void Main() {

      Graphics graphics = new Graphics("Agents");
      MainState state = new MainState(graphics);

      state.Start();
      while (graphics.Open) {
        state.Update();
        state.Draw();
      }
      state.End();

    }

  }

}