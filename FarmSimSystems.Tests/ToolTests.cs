using FarmSimSystems.Enums;

namespace FarmSimSystems.Tests;

public class ToolTests
{
    [Fact]
    public void LevelOne_ToolAffects_OnePlot()
    {
        var hoe = new Tool(1, "Hoe", 1, 2);
        var playerPosition = new Position(2, 2);
        var plots = hoe.GetAffectedPlots(playerPosition, Direction.East);

        Assert.Equal(1, plots.Count);
        Assert.Equal(3, plots[0].Col);
        Assert.Equal(2, plots[0].Row);
    }

    [Fact]
    public void LevelTwo_ToolAffects_ThreePlots()
    {
        var hoe = new Tool(1, "Hoe", 2, 2);
        var playerPosition = new Position(2, 2);
        var plots = hoe.GetAffectedPlots(playerPosition, Direction.East);

        Assert.Equal(3, plots.Count);
        Assert.Equal(3, plots[0].Col);
        Assert.Equal(2, plots[0].Row);
    }

    [Fact]
    public void LevelThree_ToolAffects_NinePlots()
    {
        var hoe = new Tool(1, "Hoe", 3, 2);
        var playerPosition = new Position(2, 2);
        var plots = hoe.GetAffectedPlots(playerPosition, Direction.East);

        Assert.Equal(9, plots.Count);
        Assert.Equal(3, plots[1].Col);
        Assert.Equal(2, plots[1].Row);
    }
}