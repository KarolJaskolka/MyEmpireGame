using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa podrzędna klasy Building
    /// zamek
    /// jego wybudowania jest warunkiem koniecznym do rozpoczęcia budowy innych budynków
    /// </summary>
    public class Castle : Building
    {
        // konstrukor
        public Castle(int level) : base(level) {
            costGold = 500;
            costIron = 100;
            costWood = 100;
            costRock = 500;
            costClay = 400;
            UpgradeToLevel(level);
        }
        /// <summary>
        /// nadpisana metoda ulepszenia o jeden
        /// </summary>
        public override void Upgrade()
        {
            level = 1;
        }
        /// <summary>
        /// nadpisana metoda ulepszenia do dowolnego poziomu (w tym wypadku tylko do 1 poziomu)
        /// </summary>
        /// <param name="toLevel"></param>
        public override void UpgradeToLevel(int toLevel)
        {
            level = 1;
        }
    }
}
