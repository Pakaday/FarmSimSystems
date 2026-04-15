using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSimSystems
{
    public enum CropStage
    {
        Seed,
        Sprout,
        Mature,
        Harvest
    }
    public class Crop
    {
        public string Name { get; set; }
        public int daysPerStage { get; set; }
        public int daysInCurrentStage { get; set; }
        public CropStage currentStage { get; set; }
        public Item HarvestItem { get; set; }

        public Crop(string name, int daysPerStage, Item harvestItem)
        {
            Name = name;
            this.daysPerStage = daysPerStage;
            daysInCurrentStage = 0;
            HarvestItem = harvestItem;
            currentStage = CropStage.Seed;
        }

        public void AdvanceDay()
        {
            daysInCurrentStage++;

            if (daysInCurrentStage >= daysPerStage)
            {
                if (currentStage < CropStage.Harvest) { 
                    currentStage++;
                    daysInCurrentStage = 0;
                }
            }
        }
    }
}
