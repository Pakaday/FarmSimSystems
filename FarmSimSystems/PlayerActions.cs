using FarmSimSystems.Interfaces;

namespace FarmSimSystems
{
    public class PlayerActions
    {
        public IField field { get; }
        public IInventory inventory { get; }

        public PlayerActions(IField field, IInventory inventory)
        {
            this.field = field;
            this.inventory = inventory;
        }

        public void Till(int row, int col)
        {
            var plot = field.GetPlot(row, col);

            if (plot.currentState == PlotState.Planted)
            {
                if (plot.currentCrop.currentStage != CropStage.Seed)
                {
                    return;
                }
            }

            plot.Till(inventory);
        }

        public void Plant(int row, int col, SeedItem seed)
        {
            var plot = field.GetPlot(row, col);

            if (plot.currentState != PlotState.Tilled)
            {
                return;
            }

            var crop = new Crop(seed.Name, seed.daysPerStage, new Item(seed.Id, seed.Name, 1, seed.Rarity));
            plot.Plant(crop);
            inventory.RemoveItem(seed);
        }

        public void Water(int row, int col)
        {
            var plot = field.GetPlot(row, col);

            if (plot.isWatered)
            {
                return;
            }

            plot.Water();
        }

        public void Harvest(int row, int col)
        {
            var plot = field.GetPlot(row, col);

            if (plot.currentState != PlotState.Planted || plot.currentCrop.currentStage != CropStage.Harvest)
            {
                return;
            }
            plot.Harvest(inventory);
        }
    }
}
