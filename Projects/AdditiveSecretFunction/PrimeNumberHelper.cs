﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AdditiveSecretFunction
{
    public class PrimeNumberHelper
    {
        public static List<int> GetPrimesLessThan(int limit)
        {
            var primes = new List<int>();
            var maxSquareRoot = (int)Math.Sqrt(limit);
            var eliminated = new BitArray(limit + 1);

            for (var testNumber = 2; testNumber <= limit; testNumber++)
            {
                if (!eliminated[testNumber])
                {
                    primes.Add(testNumber);
                    if (testNumber <= maxSquareRoot)
                    {
                        for (var j = testNumber * testNumber; j <= limit; j += testNumber)
                        {
                            eliminated[j] = true;
                        }
                    }
                }
            }
            return primes;
        }
    }
}