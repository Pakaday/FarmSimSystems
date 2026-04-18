namespace FarmSimSystems.Tests;

public class CropTests
{
    [Fact]
    public void NewCrop_StartsAtSeedStage()
    {
        var wheat = new Item(1, "Wheat", 1, Rarity.Bronze);
        var crop = new Crop("Wheat", 3, wheat);

        Assert.Equal(CropStage.Seed, crop.currentStage);
    }

    [Fact]
    public void AdvanceDay_ProgressesThroughStages()
    {
        var wheat = new Item(1, "Wheat", 1, Rarity.Bronze);
        var crop = new Crop("Wheat", 2, wheat);

        crop.AdvanceDay();
        crop.AdvanceDay();

        Assert.Equal(CropStage.Sprout, crop.currentStage);
    }

    [Fact]
    public void AdvanceDay_StopsAtHarvestStage()
    {
        var wheat = new Item(1, "Wheat", 1, Rarity.Bronze);
        var crop = new Crop("Wheat", 1, wheat);

        crop.AdvanceDay();
        crop.AdvanceDay();
        crop.AdvanceDay();
        Assert.Equal(CropStage.Harvest, crop.currentStage);
    }
}