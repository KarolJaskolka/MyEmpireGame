using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// budynek cegielni
    /// zawiera zmienna decydująca o szybkości produkcji gliny
    /// </summary>
    public class Brickyard : Building
    {
        /// <summary>
        /// ilość gliny wytwarzana w ciągu godziny
        /// </summary>
        private int clayPerHour;
        // konstrukor
        public Brickyard(int level) : base(level)
        {
            clayPerHour = 0;
            costGold = 100;
            costIron = 200;
            costWood = 100;
            costRock = 100;
            costClay = 200;
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
                        clayPerHour = 25;
                        SetCostAll(200, 300, 200, 200, 300);
                        break;
                    case 2:
                        clayPerHour = 50;
                        SetCostAll(300, 400, 300, 300, 400);
                        break;
                    case 3:
                        clayPerHour = 100;
                        SetCostAll(500, 750, 500, 750, 750);
                        break;
                    case 4:
                        clayPerHour = 200;
                        SetCostAll(1000, 1000, 1000, 2000, 1500);
                        break;
                    case 5:
                        clayPerHour = 350;
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
                    clayPerHour = 0;
                    break;
                case 1:
                    clayPerHour = 25;
                    break;
                case 2:
                    clayPerHour = 50;
                    break;
                case 3:
                    clayPerHour = 100;
                    break;
                case 4:
                    clayPerHour = 200;
                    break;
                case 5:
                    clayPerHour = 350;
                    break;
                default:
                    break;
            }
        }
        // getter
        public int GetClayPerHour()
        {
            return clayPerHour;
        }
    }
}
