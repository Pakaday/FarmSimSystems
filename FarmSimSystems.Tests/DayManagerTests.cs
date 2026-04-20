using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSimSystems.Tests
{
    public class DayManagerTests
    {
        [Fact]
        public void NewDayManager_StartsOnDayOne()
        {
            // Arrange
            Field field = new Field(2,2);
            Inventory inventory = new Inventory();
            DayManager dayManager = new DayManager(field, inventory);
            // Act
            int startingDay = dayManager.currentDay;
            // Assert
            Assert.Equal(1, startingDay);
        }

        [Fact]
        public void AdvanceDay_IncrementsCurrentDay()
        {
            Field field = new Field(2, 2);
            Inventory inventory = new Inventory();
            DayManager dayManager = new DayManager(field, inventory);

            int startingDay = dayManager.currentDay;
            dayManager.AdvanceDay();

            Assert.Equal(2, dayManager.currentDay);
        }

        [Fact]
        public void AdvanceDay_AdvancesField()
        {
            Field field = new Field(2, 2);
            Inventory inventory = new Inventory();
            DayManager dayManager = new DayManager(field, inventory);

            Plot plot = dayManager.field.GetPlot(0, 0);
            plot.isWatered = true;
            dayManager.AdvanceDay();

            Assert.False(plot.isWatered);
        }
    }
}
