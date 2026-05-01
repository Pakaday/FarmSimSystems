using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSimSystems.Extensions
{
    public static class RarityExtensions
    {
        public static float GetPriceMultiplier(this Rarity rarity)
        {
            return rarity switch
            {
                Rarity.Bronze => 1.0f,
                Rarity.Silver => 1.5f,
                Rarity.Gold => 2.0f,
                _ => 1.0f
            };
        }
    }
}
