using FarmSimSystems;

namespace FarmSimSystems.Tests;

public class InventoryTests
{
    [Fact]
    public void AddItem_NewItem_AddsToInventory()
    {
        var inventory = new Inventory();
        var wheat = new Item(1, "Wheat", 5, Rarity.Bronze);

        inventory.AddItem(wheat);

        Assert.Equal(5, inventory.GetItem(1).Quantity);
    }

    [Fact]
    public void AddItem_ExistingItem_IncrementsQuantity()
    {
        var inventory = new Inventory();
        var wheat = new Item(1, "Wheat", 1, Rarity.Bronze);

        inventory.AddItem(wheat);
        inventory.AddItem(wheat);

        Assert.Equal(2, inventory.GetItem(1).Quantity);
    }

    [Fact]
    public void RemoveItem_ReducesQuantity()
    {
        var inventory = new Inventory();
        var wheat = new Item(1, "Wheat", 5, Rarity.Bronze);

        inventory.AddItem(wheat);
        inventory.RemoveItem(new Item(1, "Wheat", 2, Rarity.Bronze));
    }
}