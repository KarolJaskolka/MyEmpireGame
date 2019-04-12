using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// tartak
    /// zawiera zmienna decydująca o szybkości produkcji drewna
    /// </summary>
    public class Sawmill : Building
    {
        /// <summary>
        /// ilość drewna wytwarzana w ciągu godziny
        /// </summary>
        private int woodPerHour;

        public Sawmill(int level) : base(level)
        {
            woodPerHour = 0;
            costGold = 100;
            costIron = 200;
            costWood = 500;
            costRock = 100;
            costClay = 100;
            UpgradeToLevel(level);
        }
        /// <summary>
        /// nadpisana metoda ulepszenia o jeden poziom
        /// </summary>
        public override void Upgrade()
        {
            if (level != Building.MAX_LEVEL)
            {
                level++;
                switch (level)
                {
                    case 1:
                        woodPerHour = 25;
                        SetCostAll(200, 300, 600, 200, 200);
                        break;
                    case 2:
                        woodPerHour = 50;
                        SetCostAll(300, 400, 750, 300, 300);
                        break;
                    case 3:
                        woodPerHour = 100;
                        SetCostAll(500, 500, 1000, 750, 750);
                        break;
                    case 4:
                        woodPerHour = 250;
                        SetCostAll(1500, 1500, 2500, 2000, 2000);
                        break;
                    case 5:
                        woodPerHour = 500;
                        break;
                }
            }
        }
        // getter
        public int GetWoodPerHour()
        {
            return woodPerHour;
        }
        /// <summary>
        /// nadpisana metoda ulepszenia do dowolnego poziomu
        /// </summary>
        /// <param name="toLevel"></param>
        public override void UpgradeToLevel(int toLevel)
        {
            switch (toLevel)
            {
                case 0:
                    woodPerHour = 0;
                    break;
                case 1:
                    woodPerHour = 25;
                    break;
                case 2:
                    woodPerHour = 50;
                    break;
                case 3:
                    woodPerHour = 100;
                    break;
                case 4:
                    woodPerHour = 250;
                    break;
                case 5:
                    woodPerHour = 500;
                    break;
                default:
                    break;
            }
        }
    }
}
