using FarmSimSystems.Enums;
using FarmSimSystems.Interfaces;
using Moq;

namespace FarmSimSystems.Tests;

public class PlayerTests
{
    [Fact]
    public void NewPlayer_HasCorrectStartingValues()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        Assert.Equal("Freddie", player.Name);
        Assert.Equal(100, player.Energy);
        Assert.Equal(100, player.MaxEnergy);
        Assert.Equal(mockInventory.Object, player.inventory);
        Assert.Equal(50, player.Money);
        Assert.Equal(mockTool.Object, player.currentTool);
        Assert.Equal(0, player.playerPosition.Row);
        Assert.Equal(0, player.playerPosition.Col);
        Assert.Equal(Direction.North, player.facing);
    }

    [Fact]
    public void Sleep_RestoresEnergyToMax()
    {

    }

    [Fact]
    public void ConsumeEnergy_ReducesEnergy()
    {

    }

    [Fact]
    public void ConsumeEnergy_DoesNotGoBelowZero()
    {

    }

    [Fact]
    public void CanAct_ReturnsFalse_WhenEnergyIsZero()
    {
    }

    [Fact]
    public void SetPosition_UpdatesFacing()
    {

    }

    [Fact]
    public void SetFacing_UpdatesFacing()
    {

    }
}