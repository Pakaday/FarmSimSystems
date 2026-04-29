using FarmSimSystems.Enums;

namespace FarmSimSystems.Interfaces;

public interface ITool
{
    int Id { get; }
    string Name { get; }
    int Level { get; }
    int EnergyCostPerPlot { get; }
    List<Position> GetAffectedPlots(Position playerPosition, Direction facing);
}