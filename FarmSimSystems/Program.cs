namespace  FarmSimSystems;
public class Program
{
    public static void Main(string[] args)
    {
        //Inventory inventory = new Inventory();

        //Item wheat = new Item(1, "Wheat", 10, Rarity.Bronze);
        //Item corn = new Item(2, "Corn", 5, Rarity.Silver);
        //Item goldCoin = new Item(3, "Gold Coin", 100, Rarity.Gold);

        //inventory.AddItem(wheat);
        //inventory.AddItem(corn);
        //inventory.AddItem(goldCoin);

        //Console.WriteLine($"Inventory has {inventory.GetItem(1)?.Quantity} Wheat.");
        //Console.WriteLine($"Inventory has {inventory.GetItem(2)?.Quantity} Corn.");
        //Console.WriteLine($"Inventory has {inventory.GetItem(3)?.Quantity} Gold Coins.");

        //inventory.RemoveItem(new Item(1, "Wheat", 5, Rarity.Bronze));
        //Console.WriteLine($"After removing 5 Wheat, inventory has {inventory.GetItem(1)?.Quantity} Wheat.");

        //inventory.RemoveItem(new Item(1, "Wheat", 5, Rarity.Bronze));
        //Console.WriteLine($"After removing another 5 Wheat, inventory has {inventory.GetItem(1)?.Quantity} Wheat.");

        Crop wheat = new Crop("Wheat", 2);
        Console.WriteLine($"Day 0: {wheat.currentStage}");

        for (int i = 1; i <= 10; i++)
        {
            wheat.AdvanceDay();
            Console.WriteLine($"Day {i}: {wheat.currentStage}");
        }
    }
}