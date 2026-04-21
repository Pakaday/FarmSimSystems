
namespace FarmSimSystems.Interfaces
{
    public interface IField
    {
        Plot GetPlot(int row, int col);
        void AdvanceDay();
        void ExpandField(int newRows, int newCols);
    }
}
