using System.Collections.Generic;

namespace AdditiveSecretFunction.Services.Abstract
{
    public interface IPrimeNumberService
    {
        List<int> GetPrimesLessThan(int limit);
    }
}