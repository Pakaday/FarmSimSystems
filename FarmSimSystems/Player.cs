using FarmSimSystems.Enums;
using FarmSimSystems.Interfaces;

namespace FarmSimSystems;

public class Player
{
    public string Name { get; set; }
    public int Energy { get; set; }
    public int MaxEnergy { get; set; }
    public IInventory inventory { get; set; }
    public int Money { get; set; }
    public Tool currentTool { get; set; }
    public Position playerPosition { get; set; }
    public Direction facing { get; set; }

    public Player(string name, int energy, int maxEnergy, IInventory inventory, int money, Tool currentTool,
        Position playerPosition, Direction facing)
    {
        Name = name;
        Energy = energy;
        MaxEnergy = maxEnergy;
        this.inventory = inventory;
        Money = money;
        this.currentTool = currentTool;
        this.playerPosition = playerPosition;
        this.facing = facing;
    }

    public void SetPosition(Position position)
    {
        playerPosition = position;
    }

    public void SetFacing(Direction direction)
    {
        facing = direction;
    }

    public void Sleep()
    {
        if (Energy < MaxEnergy)
        {
            Energy = MaxEnergy;
        }
    }

    public void ConsumeEnergy(int amount)
    {
        Energy -= amount;
        if (Energy < 0)
        {
            Energy = 0;
        }
    }

    public bool CanAct()
    {
        return Energy > 0;
    }
}