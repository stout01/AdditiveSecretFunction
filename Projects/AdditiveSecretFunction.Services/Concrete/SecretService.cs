using System;
using System.Collections.Generic;

namespace AdditiveSecretFunction.Services.Concrete
{
    public class SecretService
    {
        private readonly List<Func<int, int>> _actions = new List<Func<int, int>>
        {
            x => x,
            x => x + 1,
            x => x * 2,
            x => x / 5
        };

        private static readonly Random Rnd = new Random();

        public Func<int, int> SecretFunction
        {
            get
            {
                var r = Rnd.Next(_actions.Count);
                return _actions[r];
            }
        }
    }
}