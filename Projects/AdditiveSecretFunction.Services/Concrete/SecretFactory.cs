using System;
using System.Collections.Generic;

namespace AdditiveSecretFunction.Services.Concrete
{
    public class SecretFactory
    {
        private static readonly Random Rnd = new Random();

        private readonly List<Func<int, int>> _actions = new List<Func<int, int>>
        {
            x => x,
            x => x + 1,
            x => x*2,
            x => x/5
        };

        public Func<int, int> CreateNewSecretFunction()
        {
            var r = Rnd.Next(_actions.Count);
            return _actions[r];
        }
    }
}