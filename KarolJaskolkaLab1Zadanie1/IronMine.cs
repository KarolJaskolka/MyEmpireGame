using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// budynek kopalni żelaza
    /// zawiera zmienna decydująca o szybkości produkcji żelaza
    /// </summary>
    public class IronMine : Building
    {
        /// <summary>
        /// ilość zelaża wydobywana w ciągu godziny
        /// </summary>
        private int ironPerHour;
        // konstrukor
        public IronMine(int level) : base(level)
        {
            ironPerHour = 0;
            costGold = 100;
            costIron = 200;
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
                        ironPerHour = 10;
                        SetCostAll(200, 300, 200, 200, 200);
                        break;
                    case 2:
                        ironPerHour = 25;
                        SetCostAll(300, 400, 300, 300, 300);
                        break;
                    case 3:
                        ironPerHour = 50;
                        SetCostAll(500, 750, 500, 1000, 1000);
                        break;
                    case 4:
                        ironPerHour = 100;
                        SetCostAll(1000, 1500, 1000, 2500, 2500);
                        break;
                    case 5:
                        ironPerHour = 200;
                        break;
                }
            }
        }
        // getter
        public int GetIronPerHour()
        {
            return ironPerHour;
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
                    ironPerHour = 0;
                    break;
                case 1:
                    ironPerHour = 10;
                    break;
                case 2:
                    ironPerHour = 25;
                    break;
                case 3:
                    ironPerHour = 50;
                    break;
                case 4:
                    ironPerHour = 100;
                    break;
                case 5:
                    ironPerHour = 200;
                    break;
                default:
                    break;
            }
        }
    }
}
