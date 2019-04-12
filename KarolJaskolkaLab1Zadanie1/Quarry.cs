using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// kamieniołom
    /// zawiera zmienna decydująca o szybkości produkcji kamienia
    /// </summary>
    public class Quarry : Building
    {
        /// <summary>
        /// ilość kamienia wytwarzana w ciągu godziny
        /// </summary>
        private int rockPerHour;
        // konstrukor
        public Quarry(int level) : base(level)
        {
            rockPerHour = 0;
            costGold = 100;
            costIron = 100;
            costWood = 100;
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
                        rockPerHour = 25;
                        SetCostAll(200, 200, 200, 200, 200);
                        break;
                    case 2:
                        rockPerHour = 75;
                        SetCostAll(300, 300, 300, 300, 300);
                        break;
                    case 3:
                        rockPerHour = 150;
                        SetCostAll(500, 500, 500, 750, 750);
                        break;
                    case 4:
                        rockPerHour = 400;
                        SetCostAll(1000, 1000, 1000, 2000, 2000);
                        break;
                    case 5:
                        rockPerHour = 750;
                        break;
                }
            }
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
                    rockPerHour = 0;
                    break;
                case 1:
                    rockPerHour = 25;
                    break;
                case 2:
                    rockPerHour = 75;
                    break;
                case 3:
                    rockPerHour = 150;
                    break;
                case 4:
                    rockPerHour = 500;
                    break;
                case 5:
                    rockPerHour = 1000;
                    break;
                default:
                    break;
            }
        }
        // getter
        public int GetRockPerHour()
        {
            return rockPerHour;
        }
    }
}
