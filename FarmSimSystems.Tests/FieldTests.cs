namespace FarmSimSystems.Tests;

public class FieldTests
{
    [Fact]
    public void NewField_AllPlotsStartUntilled()
    {
        var field = new Field(5, 5);

        Assert.Equal(PlotState.Untilled, field.plots[0, 0].currentState);
        Assert.Equal(PlotState.Untilled, field.plots[4, 4].currentState);
    }

    [Fact]
    public void GetPlot_ReturnsCorrectPlot()
    {
        var field = new Field(5, 5);
        var plot = field.GetPlot(2, 3);

        Assert.Equal(field.plots[2, 3], plot);
    }

    [Fact]
    public void AdvanceDay_AdvancesAllPlots()
    {
        var field = new Field(5, 5);

        field.GetPlot(0, 0).Water();
        field.AdvanceDay();

        Assert.False(field.GetPlot(0, 0).isWatered);
    }

    [Fact]
    public void ExpandField_IncreasesSize()
    {
        var field = new Field(5, 5);

        field.ExpandField(6, 6);

        Assert.Equal(6, field.Rows);
        Assert.Equal(6, field.Cols);
    }

    [Fact]
    public void ExpandField_PreservesExistingPlots()
    {
        var field = new Field(5, 5);

        field.GetPlot(0, 0).currentState = PlotState.Untilled;
        field.GetPlot(1, 1).currentState = PlotState.Tilled;
        field.GetPlot(2, 2).currentState = PlotState.Planted;
        field.ExpandField(6, 6);

        Assert.Equal(PlotState.Untilled, field.GetPlot(0, 0).currentState);
        Assert.Equal(PlotState.Tilled, field.GetPlot(1, 1).currentState);
        Assert.Equal(PlotState.Planted, field.GetPlot(2, 2).currentState);
        Assert.Equal(6, field.Rows);
        Assert.Equal(6, field.Cols);
    }
}

