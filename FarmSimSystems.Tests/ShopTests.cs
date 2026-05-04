using FarmSimSystems.Enums;
using FarmSimSystems.Interfaces;
using Moq;

namespace FarmSimSystems.Tests;

public class ShopTests
{
    [Fact]
    public void BuyItem_PlayerHasEnoughMoney_ReturnsTrueAndDeductsMoney()
    {
        var shop = new Shop();
        var shopItem = new ShopItem(new Item(1, "Wheat", 5, Rarity.Bronze, 10f));
        var inventory = new Inventory();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, new Inventory(), 1000, mockTool.Object, new Position(0, 0), Direction.East);

        shop.items.Add(shopItem);
        var result = shop.BuyItem(player, shopItem);

        Assert.True(result);
    }

    [Fact]
    public void BuyItem_PlayerNotEnoughMoney_ReturnsFalse()
    {
        var shop = new Shop();
        var shopItem = new ShopItem(new Item(1, "Wheat", 5, Rarity.Bronze, 10f));
        var inventory = new Inventory();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, new Inventory(), 5, mockTool.Object, new Position(0, 0), Direction.East);

        shop.items.Add(shopItem);
        var result = shop.BuyItem(player, shopItem);

        Assert.False(result);
    }

    [Fact]
    public void BuyItem_ItemNotInStock_ReturnsFalse()
    {
        var shop = new Shop();
        var shopItem = new ShopItem(new Item(1, "Wheat", 0, Rarity.Bronze, 10f));
        var inventory = new Inventory();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, new Inventory(), 1000, mockTool.Object, new Position(0, 0), Direction.East);

        shop.items.Add(shopItem);
        var result = shop.BuyItem(player, shopItem);

        Assert.True(result);
    }

    [Fact]
    public void SellItem_ItemInCatalog_ReturnsTrueAndAddsMoney()
    {
        var shop = new Shop();
        var shopItem = new ShopItem(new Item(1, "Wheat", 5, Rarity.Bronze, 10f));
        var inventory = new Inventory();
        var item = new Item(1, "Wheat", 5, Rarity.Bronze, 10f);
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, new Inventory(), 0, mockTool.Object, new Position(0, 0), Direction.East);

        shop.items.Add(shopItem);
        var result = shop.SellItem(player, item);

        Assert.True(result);
        Assert.True(player.Money == 5);
    }

    [Fact]
    public void SellItem_ItemNotInCatalog_ReturnsFalse()
    {
        var shop = new Shop();
        var shopItem = new ShopItem(new Item(1, "Wheat", 5, Rarity.Bronze, 10f));
        var inventory = new Inventory();
        var item = new Item(2, "Corn", 5, Rarity.Bronze, 10f);
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, new Inventory(), 0, mockTool.Object, new Position(0, 0), Direction.East);

        shop.items.Add(shopItem);
        var result = shop.SellItem(player, item);

        Assert.False(result);
        Assert.True(player.Money == 0);
    }

}