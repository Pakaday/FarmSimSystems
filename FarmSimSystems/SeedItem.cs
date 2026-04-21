namespace FarmSimSystems;

public class SeedItem : Item
{
    public int daysPerStage { get; set; }

    public SeedItem(int id, string name, int quantity, Rarity rarity, int daysPerStage) : base (id, name, quantity, rarity)
    {
        this.daysPerStage = daysPerStage;
    }
}