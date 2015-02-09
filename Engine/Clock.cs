using System;
using System.Diagnostics;

namespace Engine {

  public class Clock {

    public Clock() {
      watch = Stopwatch.StartNew();
    }

    public float Restart() {
      float res = Elapsed;
      watch.Restart();
      return res;
    }

    public float Elapsed {
      get {
        return watch.ElapsedMilliseconds / 1000f;
      }
    }

    private Stopwatch watch;

  }

}