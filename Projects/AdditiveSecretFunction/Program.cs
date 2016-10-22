using System;
using CommandLine;

namespace AdditiveSecretFunction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArgumentsStrict(args, options, OnFail);

            var primes = PrimeNumberHelper.GetPrimesLessThan(options.Limit);

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

        private static void OnFail()
        {
            Environment.Exit(-1);
        }
    }
}