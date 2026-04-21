using FarmSimSystems.Interfaces;

namespace FarmSimSystems;

public class Inventory : IInventory
{
    private Dictionary<int, Item> items = new Dictionary<int, Item>();

    public void AddItem(Item item)
    {
        {
            if (items.ContainsKey(item.Id))
            {
                items[item.Id].Quantity += item.Quantity;
            }
            else
            {
                items.Add(item.Id, item);
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.ContainsKey(item.Id))
        {
            items[item.Id].Quantity -= item.Quantity;

            if (items[item.Id].Quantity <= 0)
            {
                items.Remove(item.Id);
            }
        }
    }

    public Item GetItem(int id)
    {
        if (items.ContainsKey(id))
        {
            return items[id];
        }
        return null;
    }
}