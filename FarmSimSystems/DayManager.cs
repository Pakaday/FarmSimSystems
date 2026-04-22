using FarmSimSystems.Interfaces;

namespace FarmSimSystems
{
    public class DayManager
    {
        public IField field { get; }
        public IInventory inventory { get; }
        public int currentDay { get; set; }

        public DayManager(IField field, IInventory inventory)
        {
            this.field = field;
            this.inventory = inventory;
            currentDay = 1;
        }

        public void AdvanceDay()
        {
            currentDay++;
            field.AdvanceDay();
        }
    }
}
