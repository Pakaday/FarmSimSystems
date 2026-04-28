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
}