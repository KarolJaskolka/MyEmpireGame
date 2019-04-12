using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// budynek kopalni złota
    /// zawiera zmienna decydująca o szybkości produkcji złota
    /// </summary>
    public class GoldMine : Building
    {
        /// <summary>
        /// ilość złota wydobywana w ciągu godziny
        /// </summary>
        private int goldPerHour;
        // konstrukor
        public GoldMine(int level) : base(level)
        {
            goldPerHour = 0;
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
            if(level != Building.MAX_LEVEL)
            {
                level++;
                switch (level)
                {
                    case 1:
                        goldPerHour = 20;
                        SetCostAll(200, 300, 200, 200, 200);
                        break;
                    case 2:
                        goldPerHour = 50;
                        SetCostAll(300, 400, 300, 500, 500);
                        break;
                    case 3:
                        goldPerHour = 100;
                        SetCostAll(500, 750, 500, 1250, 1250);
                        break;
                    case 4:
                        goldPerHour = 150;
                        SetCostAll(1000, 1500, 1000, 2500, 2500);
                        break;
                    case 5:
                        goldPerHour = 250;
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
                    goldPerHour = 0;
                    break;
                case 1:
                    goldPerHour = 20;
                    break;
                case 2:
                    goldPerHour = 50;
                    break;
                case 3:
                    goldPerHour = 75;
                    break;
                case 4:
                    goldPerHour = 150;
                    break;
                case 5:
                    goldPerHour = 250;
                    break;
                default:
                    break;
            }
        }
        // getter
        public int GetGoldPerHour()
        {
            return goldPerHour;
        }
    }
}
