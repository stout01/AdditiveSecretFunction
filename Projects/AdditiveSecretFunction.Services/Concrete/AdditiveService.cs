using System;
using AdditiveSecretFunction.Services.Abstract;

namespace AdditiveSecretFunction.Services.Concrete
{
    public class AdditiveService : IAdditiveService
    {
        private readonly IPrimeNumberService _primeNumberService;

        public AdditiveService(IPrimeNumberService primeNumberService)
        {
            _primeNumberService = primeNumberService;
        }

        public bool IsAdditive(Func<int, int> secret, int limit)
        {
            var primes = _primeNumberService.GetPrimesLessThan(limit);

            foreach (var x in primes)
            {
                for (var index = x; index < primes.Count; index++)
                {
                    var y = primes[index];

                    if (secret(x + y) != secret(x) + secret(y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}