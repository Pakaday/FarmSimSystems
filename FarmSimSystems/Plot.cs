namespace FarmSimSystems;

public enum PlotState
{
    Untilled,
    Tilled,
    Planted
}

public class Plot
{
    public PlotState currentState { get; set; }
    public bool isWatered { get; set; }
    public Crop currentCrop { get; set; }

    public Plot()
    {
        currentState = PlotState.Untilled;
        isWatered = false;
        currentCrop = null;
    }

    public void Till(Inventory inventory)
    {
        if (currentState == PlotState.Untilled)
        {
            currentState = PlotState.Tilled;
        }
        else if (currentState == PlotState.Tilled)
        {
            inventory.AddItem(currentCrop.HarvestItem);
            currentCrop = null;
            currentState = PlotState.Tilled;
        }
    }

    public void Plant(Crop crop)
    {
        if (currentState == PlotState.Tilled)
        {
            currentCrop = crop;
            currentState = PlotState.Planted;
        }
    }

    public void Water()
    {
        if (!isWatered)
        {
            isWatered = true;
        }
    }

    public void AdvanceDay()
    {
        if (currentState == PlotState.Planted)
        {
            currentCrop.AdvanceDay();
        }

        if (isWatered)
        {
            isWatered = false;
        }
    }
}