using System;
using System.Collections.Generic;

namespace AdditiveSecretFunction
{
    public class SecretService
    {
        private static readonly List<Func<int, int>> Actions = new List<Func<int, int>>
        {
            x => x,
            x => x + 1,
            x => x * 2,
            x => x / 5
        };

        private static readonly Random Rnd = new Random();

        public static Func<int, int> SecretFunction
        {
            get
            {
                var r = Rnd.Next(Actions.Count);
                return Actions[r];
            }
        }
    }
}