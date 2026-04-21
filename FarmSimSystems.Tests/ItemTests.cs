namespace FarmSimSystems.Tests;

public class ItemTests
{
    [Fact]
    public void NewItem_HasCorrectProperties()
    {
        var item = new Item(1, "Wheat", 5, Rarity.Bronze);

        Assert.Equal(1, item.Id);
        Assert.Equal("Wheat", item.Name);
        Assert.Equal(5, item.Quantity);
        Assert.Equal(Rarity.Bronze, item.Rarity);
    }
}