namespace FarmSimSystems;

public class Field
{
    public int Rows { get; set; }
    public int Cols { get; set; }
    public Plot[,] plots;

    public Field(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        plots = new Plot[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                plots[r, c] = new Plot();
            }
        }
    }

    public Plot GetPlot(int row, int col)
    {
        return plots[row, col];
    }

    public void AdvanceDay()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                plots[r, c].AdvanceDay();
            }
        }
    }

    public void ExpandField(int newRows, int newCols)
    {
        Plot[,] newPlots = new Plot[newRows, newCols];

        for (int r = 0; r < newRows; r++)
        {
            for (int c = 0; c < newCols; c++)
            {
                if (r < Rows && c < Cols)
                {
                    newPlots[r, c] = plots[r, c];
                }
                else
                {
                    newPlots[r, c] = new Plot();
                }
            }
        }

        plots = newPlots;
        Rows = newRows;
        Cols = newCols;
    }
}