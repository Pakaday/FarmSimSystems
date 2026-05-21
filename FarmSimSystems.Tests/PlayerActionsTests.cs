using FarmSimSystems.Enums;
using Moq;
using FarmSimSystems.Interfaces;

namespace FarmSimSystems.Tests
{
    public class PlayerActionsTests
    {
        private Player CreateDefaultPlayer(IInventory inventory)
        {
            return new Player("Freddie", 100, 100, inventory, 50, new Tool(1, "Hoe", 1, 2), new Position(1, 1), Direction.North);
        }

        [Fact]
        public void Till_UntilledPlot_TransitionsToTilled()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, CreateDefaultPlayer(mockInventory.Object));
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Till();

            Assert.Equal(PlotState.Tilled, plot.currentState);
        }

        [Fact]
        public void Plant_TilledPlot_AddsCropAndRemovesSeed()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, CreateDefaultPlayer(mockInventory.Object));
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
            var playerActions = new PlayerActions(mockField.Object, CreateDefaultPlayer(mockInventory.Object));
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Water();

            Assert.True(plot.isWatered);
        }

        [Fact]
        public void Harvest_HarvestStageCrop_AddsItemToInventory()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var playerActions = new PlayerActions(mockField.Object, CreateDefaultPlayer(mockInventory.Object));
            var harvestItem = new Item(1, "Wheat", 1, Rarity.Bronze, 10f);
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

        [Fact]
        public void Till_NotEnoughEnergy_DoesNotTill()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var player = CreateDefaultPlayer(mockInventory.Object);
            player.Energy = 1;
            var playerActions = new PlayerActions(mockField.Object, player);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Till();

            Assert.Equal(PlotState.Untilled, plot.currentState);
        }

        [Fact]
        public void Water_NotEnoughEnergy_DoesNotWater()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var player = CreateDefaultPlayer(mockInventory.Object);
            player.Energy = 1;
            var playerActions = new PlayerActions(mockField.Object, player);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Water();

            Assert.False(plot.isWatered);
        }

        [Fact]
        public void Till_ConsumesEnergy()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var player = CreateDefaultPlayer(mockInventory.Object);
            var playerActions = new PlayerActions(mockField.Object, player);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Till();

            Assert.Equal(98, player.Energy);
        }

        [Fact]
        public void Water_ConsumesEnergy()
        {
            var mockField = new Mock<IField>();
            var mockInventory = new Mock<IInventory>();
            var player = CreateDefaultPlayer(mockInventory.Object);
            var playerActions = new PlayerActions(mockField.Object, player);
            var plot = new Plot();
            mockField.Setup(f => f.GetPlot(0, 1)).Returns(plot);

            playerActions.Water();

            Assert.Equal(98, player.Energy);
        }
    }
}
