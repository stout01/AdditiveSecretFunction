using System;

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

            var secret = SecretService.SecretFunction;

            foreach (var x in primes)
            {
                for (var index = x; index < primes.Count; index++)
                {
                    var y = primes[index];

                    if (secret(x + y) != secret(x) + secret(y))
                    {
                        Console.WriteLine("Not Additive");
                        Console.Read();
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Additive");
            Console.Read();
        }
    }
}