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
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 50, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        player.Sleep();

        Assert.Equal(100, player.Energy);
    }

    [Fact]
    public void ConsumeEnergy_ReducesEnergy()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        player.ConsumeEnergy(20);

        Assert.Equal(80, player.Energy);
    }

    [Fact]
    public void ConsumeEnergy_DoesNotGoBelowZero()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 0, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        player.ConsumeEnergy(20);

        Assert.Equal(0, player.Energy);
    }

    [Fact]
    public void CanAct_ReturnsFalse_WhenEnergyIsZero()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 0, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        Assert.False(player.CanAct());
    }

    [Fact]
    public void SetPosition_UpdatesPosition()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        player.SetPosition(new Position(1, 1));

        Assert.Equal(1, player.playerPosition.Row);
        Assert.Equal(1, player.playerPosition.Col);
    }

    [Fact]
    public void SetFacing_UpdatesFacing()
    {
        var mockInventory = new Mock<IInventory>();
        var mockTool = new Mock<ITool>();
        var player = new Player("Freddie", 100, 100, mockInventory.Object, 50, mockTool.Object, new Position(0, 0), Direction.North);

        player.SetFacing(Direction.East);

        Assert.Equal(Direction.East, player.facing);
    }
}