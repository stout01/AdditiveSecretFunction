using System;
using System.Collections.Generic;
using System.Linq;

namespace AdditiveSecretFunction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int limit;
            if (!int.TryParse(args[0], out limit))
            {
                Console.WriteLine("Invalid input");
                Console.Read();
                Environment.Exit(0);
            }

            var primes = PrimeNumberHelper.GetPrimesLessThan(limit);

            var used = new List<int>();
            foreach (var x in primes)
            {
                foreach (var y in primes.Except(used))
                {
                    if (SecretService.Secret(x + y) != SecretService.Secret(x) + SecretService.Secret(y))
                    {
                        Console.WriteLine("Not Additive");
                        Console.Read();
                        Environment.Exit(0);
                    }
                }
                used.Add(x);
            }

            Console.WriteLine("Additive");
            Console.Read();
        }
    }
}