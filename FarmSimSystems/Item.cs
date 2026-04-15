namespace FarmSimSystems;

public enum Rarity
{
    Bronze,
    Silver,
    Gold
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public Rarity Rarity { get; set; }

    public Item(int id, string name, int quantity, Rarity rarity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Rarity = rarity;
    }
}