using Moq;
using FarmSimSystems.Interfaces;

namespace FarmSimSystems.Tests
{
    public class PlayerActionsTests
    {
        [Fact]
        public void Till_UntilledPlot_TransitionsToTilled()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, mockInventory.Object);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 0)).Returns(plot);
            
            playerActions.Till(0, 0);
            
            Assert.Equal(PlotState.Tilled, plot.currentState);
        }

        [Fact]
        public void Plant_TilledPlot_AddsCropAndRemovesSeed()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, mockInventory.Object);
            var seedItem = new SeedItem(1, "Wheat Seed", 3, Rarity.Bronze, 2);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 0)).Returns(plot);
            plot.Till(mockInventory.Object);
            
            playerActions.Plant(0, 0, seedItem);
            
            Assert.Equal(PlotState.Planted, plot.currentState);
            mockInventory.Verify(i => i.RemoveItem(seedItem), Times.Once);
        }

        [Fact]
        public void Water_UnwateredPlot_SetsIsWatered()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, mockInventory.Object);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 0)).Returns(plot);
            
            playerActions.Water(0, 0);
            
            Assert.True(plot.isWatered);
        }

        [Fact]
        public void Harvest_HarvestStageCrop_AddsItemToInventory()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, mockInventory.Object);
            var harvestItem = new Item(1, "Wheat", 1, Rarity.Bronze);
            var crop = new Crop("Wheat", 2, harvestItem);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 0)).Returns(plot);
            plot.Till(mockInventory.Object);
            plot.Plant(crop);
            crop.currentStage = CropStage.Harvest;
            
            playerActions.Harvest(0, 0);
            
            Assert.Equal(PlotState.Tilled, plot.currentState);
            mockInventory.Verify(i => i.AddItem(It.IsAny<Item>()), Times.Once);

        }
    }
}
