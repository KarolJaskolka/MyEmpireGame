using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// magazyn
    /// zawiera zmienna decydująca o maksymalnej ilości zasobów jakie można przechowywać
    /// </summary>
    public class Warehouse : Building
    {
        /// <summary>
        /// pojemność magazynu na zasoby
        /// </summary>
        private int capacity;
        // konstrukor
        public Warehouse(int level) : base(level)
        {
            capacity = 10000;
            costGold = 500;
            costIron = 500;
            costWood = 2500;
            costRock = 5000;
            costClay = 5000;
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
                        capacity = 10000;
                        SetCostAll(500, 500, 2500, 5000, 5000);
                        break;
                    case 2:
                        capacity = 25000;
                        SetCostAll(750, 750, 5000, 7500, 7500);
                        break;
                    case 3:
                        capacity = 50000;
                        SetCostAll(1000, 1000, 7500, 15000, 15000);
                        break;
                    case 4:
                        capacity = 100000;
                        SetCostAll(2500, 2500, 10000, 25000, 25000);
                        break;
                    case 5:
                        capacity = 250000;
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
                    capacity = 0;
                    break;
                case 1:
                    capacity = 10000;
                    break;
                case 2:
                    capacity = 25000;
                    break;
                case 3:
                    capacity = 50000;
                    break;
                case 4:
                    capacity = 100000;
                    break;
                case 5:
                    capacity = 250000;
                    break;
                default:
                    break;
            }
        }
        // getter
        public int GetCapacity()
        {
            return capacity;
        }
    }
}
