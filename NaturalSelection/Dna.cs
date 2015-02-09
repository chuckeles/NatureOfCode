using Engine;
using System;

namespace NaturalSelection {

  public class Dna {

    public Dna(uint length, Random random) {
      this.length = length;

      text = new char[length];
      for (uint i = 0; i < length; ++i)
        text[i] = (char)random.Next(32, 128);
    }

    public float Fitness(string target) {
      float res = 0;

      for (uint i = 0; i < length; ++i)
        if (text[i] == target[(int)i])
          ++res;

      res *= res;

      return res;
    }

    public void Mutate(float chance, Random random) {
      for (uint i = 0; i < length; ++i)
        if ((float)random.NextDouble() < chance)
          text[i] = (char)random.Next(32, 128);
    }

    public static Dna Crossover(Dna dna1, Dna dna2, Random random) {
      Dna child = new Dna(dna1.length, random);

      for (uint i = 0; i < child.length; ++i) {
        float chance = (float)random.NextDouble();

        if (chance < .5)
          child.text[i] = dna1.text[i];
        else
          child.text[i] = dna2.text[i];
      }

      return child;
    }

    public char[] text;
    public uint length;

  }

}