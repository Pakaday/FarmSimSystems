

namespace FarmSimSystems
{
    public class DayManager
    {
        public Field field { get; }
        public Inventory inventory { get; }
        public int currentDay { get; set; }

        public DayManager(Field field, Inventory inventory)
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
