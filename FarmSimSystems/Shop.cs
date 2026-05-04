namespace FarmSimSystems;

public class Shop
{
    public List<ShopItem> items { get; set; }

    public Shop()
    {
        items = new List<ShopItem>();
    }

    public bool BuyItem(Player player, ShopItem shopItem)
    {
        if (player.Money < shopItem.BuyPrice || !items.Contains(shopItem)) return false;
        {
            player.Money -= shopItem.BuyPrice;
            player.inventory.AddItem(shopItem.item);
            return true;
        }
    }

    public bool SellItem(Player player, Item item)
    {
        var shopItem = items.FirstOrDefault(si => si.item.Id == item.Id);
        if (shopItem == null) return false;
        {
            player.Money += shopItem.SellPrice;
            player.inventory.RemoveItem(item);
            return true;
        }
    }
}