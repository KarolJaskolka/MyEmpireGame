using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// budynek koszar
    /// zawiera zmienna dodająca zniżke do kosztów rekrutowania wojowników
    /// </summary>
    public class Barrack : Building
    {
        /// <summary>
        /// zniżka kosztu wojowników
        /// </summary>
        private double discount;
        // konstrukor
        public Barrack(int level) : base(level)
        {
            discount = 0;
            costGold = 150;
            costIron = 150;
            costWood = 250;
            costRock = 250;
            costClay = 250;
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
                        discount = 0;
                        SetCostAll(300, 300, 400, 400, 400);
                        break;
                    case 2:
                        discount = 0.10;
                        SetCostAll(500, 500, 750, 750, 750);
                        break;
                    case 3:
                        discount = 0.25;
                        SetCostAll(1500, 2500, 1000, 2500, 2500);
                        break;
                    case 4:
                        discount = 0.50;
                        SetCostAll(5000, 5000, 4000, 5000, 5000);
                        break;
                    case 5:
                        discount = 0.75;
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
                    discount = 0;
                    break;
                case 1:
                    discount = 0;
                    break;
                case 2:
                    discount = 0.10;
                    break;
                case 3:
                    discount = 0.25;
                    break;
                case 4:
                    discount = 0.50;
                    break;
                case 5:
                    discount = 0.75;
                    break;
                default:
                    break;
            }
        }
        // getter
        public double GetDiscount()
        {
            return discount;
        }
    }
}
