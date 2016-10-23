using System;

namespace AdditiveSecretFunction.Services.Abstract
{
    public interface IAdditiveService
    {
        bool IsAdditive(Func<int, int> secret, int limit);
    }
}