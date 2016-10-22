using System;

namespace AdditiveSecretFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit;
            if (!int.TryParse(args[0], out limit))
            {
                Console.WriteLine("Invalid input");
                Console.Read();
                Environment.Exit(0);
            }

            var primes = PrimeNumberHelper.GetPrimesLessThan(limit);

            foreach (var x in primes)
            {
                foreach (var y in primes)
                {
                    if (SecretService.Secret(x + y) != (SecretService.Secret(x) + SecretService.Secret(y)))
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
