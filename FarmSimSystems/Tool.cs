using FarmSimSystems.Enums;
using FarmSimSystems.Interfaces;

namespace FarmSimSystems;

public class Tool : ITool
{
    public int Id { get; }
    public string Name { get; }
    public int Level { get; }
    public int EnergyCostPerPlot { get; }

    public Tool(int id, string name, int level, int energyCostPerPlot)
    {
        Id = id;
        Name = name;
        Level = level;
        EnergyCostPerPlot = energyCostPerPlot;
    }

    public List<Position> GetAffectedPlots(Position playerPosition, Direction facing)
    {
        List<Position> affectedPlots = new List<Position>();

        int depthRange = Level == 1 ? 1 : 3;
        int widthRange = Level == 3 ? 1 : 0;

        for (int i = 1; i <= depthRange; i++)
        {
            int rowOffset = 0;
            int colOffset = 0;

            for (int w = -widthRange; w <= widthRange; w++)
            {
                switch (facing)
                {
                    case Direction.North:
                        rowOffset = -i;
                        colOffset = w;
                        break;
                    case Direction.South:
                        rowOffset = i;
                        colOffset = w;
                        break;
                    case Direction.East:
                        rowOffset = w;
                        colOffset = i;
                        break;
                    case Direction.West:
                        rowOffset = w;
                        colOffset = -i;
                        break;
                }

                affectedPlots.Add(new Position(playerPosition.Row + rowOffset, playerPosition.Col + colOffset));
            }
        }
        return affectedPlots;
    }
}