namespace FarmSimSystems.Tests;

public class SeedItemTests
{
    [Fact]
    public void NewSeedItem_HasCorrectDaysPerStage()
    {
        var seedItem = new SeedItem(1, "Wheat Seed", 10, Rarity.Bronze, 2);

        Assert.Equal(2, seedItem.daysPerStage);
    }

    [Fact]
    public void NewSeedItem_InheritsItemProperties()
    {
        var seedItem = new SeedItem(1, "Wheat Seed", 10, Rarity.Bronze, 2);

        Assert.Equal(1, seedItem.Id);
        Assert.Equal("Wheat Seed", seedItem.Name);
        Assert.Equal(10, seedItem.Quantity);
        Assert.Equal(Rarity.Bronze, seedItem.Rarity);
    }
}