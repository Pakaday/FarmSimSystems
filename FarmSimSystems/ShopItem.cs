using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmSimSystems.Extensions;

namespace FarmSimSystems
{
    public class ShopItem
    {
        public Item item { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public ShopItem(Item item)
        {
            this.item = item;
            BuyPrice = (int)(item.BasePrice * item.Rarity.GetPriceMultiplier());
            SellPrice = (int)(BuyPrice * 0.5f);
        }
    }
}
