﻿using System;
using System.Collections.Generic;

namespace store
{
    public static class Utilites
    {
        private static readonly Random Randomizer = new Random();

        public static int GenerateNumber(int min, int max) => Randomizer.Next(min, max + 1);

        public static HashSet<int> GenerateDistinctNumbers(int min, int max, int amount)
        {
            HashSet<int> numbers = new HashSet<int>();

            while (numbers.Count < amount)
            {
                _ = numbers.Add(Randomizer.Next(min, max + 1));
            }

            return numbers;
        }
    }
}