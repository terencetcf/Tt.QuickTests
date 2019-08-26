using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickTests.ConsoleApp
{
    public static class JumpingOnClouds
    {
        public static int GetTotalSteps(int[] c)
        {
            if (c.Length < 2 || c.Length > 100 || !c.All(item => item == 0 || item == 1))
            {
                throw new InvalidOperationException("Invalid input");
            }

            var cumulus = new List<int>();
            var thunderheads = new List<int>();
            for (var i = 0; i < c.Length; i++)
            {
                if (c[i] == 1)
                {
                    thunderheads.Add(i);
                    continue;
                }

                cumulus.Add(i);
            }

            var cumulusToSkip = new List<int>();
            for (var i = 0; i < cumulus.Count() - 2; i++)
            {
                if (cumulusToSkip.Contains(cumulus[i]))
                {
                    continue;
                }

                var attempt = cumulus[i + 2] - cumulus[i];
                if (attempt <= 2)
                {
                    cumulusToSkip.Add(cumulus[i + 1]);
                }
            }

            return cumulus.Except(cumulusToSkip).Count() - 1;
        }
    }
}
