using FarmSimSystems.Interfaces;

namespace FarmSimSystems
{
    public class PlayerActions
    {
        public IField field { get; }
        public Player player { get; }

        public PlayerActions(IField field, Player player)
        {
            this.field = field;
            this.player = player;
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

            plot.Till(player.inventory);
        }

        public void Plant(int row, int col, SeedItem seed)
        {
            var plot = field.GetPlot(row, col);

            if (plot.currentState != PlotState.Tilled)
            {
                return;
            }

            var crop = new Crop(seed.Name, seed.daysPerStage, new Item(seed.Id, seed.Name, 1, seed.Rarity, 1));
            plot.Plant(crop);
            player.inventory.RemoveItem(seed);
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
            plot.Harvest(player.inventory);
        }
    }
}
