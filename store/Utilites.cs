using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public static class Utilites
    {
        private static readonly Random Randomizer = new();

        public static int GenerateNumber(int min, int max) => Randomizer.Next(min, max + 1);

        public static List<int> GenerateDistinctNumbers(int min, int max, int amount)
        {
            HashSet<int> numbers = new();

            while (numbers.Count < amount)
            {
                _ = numbers.Add(Randomizer.Next(min, max + 1));
            }

            return numbers.ToList();
        }
    }
}
