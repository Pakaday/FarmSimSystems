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

        public void Till()
        {
            if (!player.CanAct()) return;

            var affectedPlots = player.currentTool.GetAffectedPlots(player.playerPosition, player.facing);

            int cost = player.currentTool.EnergyCostPerPlot * affectedPlots.Count;

            if (player.Energy < cost) return;

            foreach (var position in affectedPlots)
            {
                var plot = field.GetPlot(position.Row, position.Col);

                if (plot.currentState == PlotState.Planted)
                {
                    if (plot.currentCrop.currentStage != CropStage.Seed)
                    {
                        continue;
                    }
                }

                plot.Till(player.inventory);
            }

            player.ConsumeEnergy(cost);
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

        public void Water()
        {
            if (!player.CanAct()) return;

            var affectedPlots = player.currentTool.GetAffectedPlots(player.playerPosition, player.facing);

            int cost = player.currentTool.EnergyCostPerPlot * affectedPlots.Count;

            if (player.Energy < cost) return;

            foreach (var position in affectedPlots)
            {
                var plot = field.GetPlot(position.Row, position.Col);

                if (plot.isWatered)
                {
                    continue;
                }

                plot.Water();
            }

            player.ConsumeEnergy(cost);
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
