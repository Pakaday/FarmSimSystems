namespace  FarmSimSystems;
public class Program
{
    public static void Main(string[] args)
    {
        Item wheat = new Item(1, "Wheat", 1, Rarity.Bronze);

        Crop wheatCrop = new Crop("Wheat", 2, wheat);

        for (int i = 1; i <= 10; i++)
        {
            wheatCrop.AdvanceDay();
            if (wheatCrop.currentStage == CropStage.Harvest)
            {
                Console.WriteLine($"Day {i}: {wheatCrop.Name} is ready to harvest! You get {wheatCrop.HarvestItem.Quantity} {wheatCrop.HarvestItem.Name}(s).");
                break;
            }
            else
            {
                Console.WriteLine($"Day {i}: {wheatCrop.Name} is at stage {wheatCrop.currentStage}.");
            }
        }
    }
}