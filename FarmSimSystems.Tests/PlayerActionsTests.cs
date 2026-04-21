using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSimSystems.Tests
{
    public class PlayerActionsTests
    {
        [Fact]
        public void Till_UntilledPlot_TransitionsToTilled()
        {
            
            var field = new Field(1, 1);
            var inventory = new Inventory();
            var playerActions = new PlayerActions(field, inventory);
            var seedItem = new SeedItem(1, "Wheat Seed", 3, Rarity.Bronze, 2);
            var crop = new Crop(seedItem.Name, seedItem.daysPerStage, new Item(seedItem.Id, seedItem.Name, 1, seedItem.Rarity));
            field.GetPlot(0, 0).Plant(crop);
            
            playerActions.Till(0, 0);
            
            Assert.Equal(PlotState.Tilled, field.GetPlot(0, 0).currentState);
        }

        [Fact]
        public void Plant_TilledPlot_AddsCropAndRemovesSeed()
        {
            
            var field = new Field(1, 1);
            var inventory = new Inventory();
            var playerActions = new PlayerActions(field, inventory);
            var seedItem = new SeedItem(1, "Wheat Seed", 3, Rarity.Bronze, 2);
            inventory.AddItem(seedItem);
            field.GetPlot(0, 0).Till(inventory);
            
            playerActions.Plant(0, 0, seedItem);
            
            Assert.Equal(PlotState.Planted, field.GetPlot(0, 0).currentState);
            Assert.Null(inventory.GetItem(seedItem.Id));
        }

        [Fact]
        public void Water_UnwateredPlot_SetsIsWatered()
        {
            
            var field = new Field(1, 1);
            var inventory = new Inventory();
            var playerActions = new PlayerActions(field, inventory);
            field.GetPlot(0, 0).Till(inventory);
            
            playerActions.Water(0, 0);
            
            Assert.True(field.GetPlot(0, 0).isWatered);
        }

        [Fact]
        public void Harvest_HarvestStageCrop_AddsItemToInventory()
        {
            var field = new Field(1, 1);
            var inventory = new Inventory();
            var playerActions = new PlayerActions(field, inventory);
            var seedItem = new SeedItem(1, "Wheat Seed", 3, Rarity.Bronze, 2);
            var crop = new Crop(seedItem.Name, seedItem.daysPerStage, new Item(seedItem.Id, seedItem.Name, 1, seedItem.Rarity));
            field.GetPlot(0, 0).Till(inventory);
            field.GetPlot(0, 0).Plant(crop);
            crop.currentStage = CropStage.Harvest;
            
            playerActions.Harvest(0, 0);
            
            Assert.Equal(PlotState.Tilled, field.GetPlot(0, 0).currentState);
            Assert.NotNull(inventory.GetItem(seedItem.Id));
        }
    }
}
