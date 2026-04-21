using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSimSystems.Interfaces
{
    public interface IInventory
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        Item GetItem(int id);
    }
}
