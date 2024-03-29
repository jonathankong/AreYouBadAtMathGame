﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace RandomExtensions
{
    static class RandomExtensions
    {
        //Knuth Shuffle
        public static void Shuffle<T>(this Random rng, List<T> array)
        {
            int n = array.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
