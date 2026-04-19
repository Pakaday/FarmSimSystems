namespace FarmSimSystems.Tests;

public class PlotTests
{
    [Fact]
    public void NewPlot_StartsUntilled()
    {
        var plot = new Plot();

        Assert.Equal(PlotState.Untilled, plot.currentState);
    }

    [Fact]
    public void Till_UntilledPlot_TransitionsToTilled()
    {
        var plot = new Plot();

        plot.Till(inventory: null);

        Assert.Equal(PlotState.Tilled, plot.currentState);
    }

    [Fact]
    public void Plant_TilledPlot_TransitionsToPlanted()
    {
        var plot = new Plot();
        var crop = (new Crop("Wheat", 3, new Item(1, "Wheat", 1, Rarity.Bronze)));

        plot.Till(inventory: null);
        plot.Plant(crop);

        Assert.Equal(PlotState.Planted, plot.currentState);
    }

    [Fact]
    public void Water_SetIsWateredTrue()
    {
        var plot = new Plot();

        plot.Water();

        Assert.Equal(true, plot.isWatered);
    }

    [Fact]
    public void AdvanceDay_ResetsWatered()
    {
        var plot = new Plot();

        plot.Water();
        plot.AdvanceDay();

        Assert.Equal(false, plot.isWatered);
    }
}