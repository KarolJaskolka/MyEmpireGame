using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// abstrakcyjna klasa bazowa dla wszystkich budynków
    /// Przechowująca koszt budowy, poziom, oraz statytczną zmienną zawierająca informacje 
    /// o maksymalnym poziomie ulepszeń wspólnym dla wszystkich budynków
    /// Posiada także abstrakcyjne metody ulepszania o jeden poziom oraz do wybranego poziomu
    /// </summary>
    public abstract class Building
    {
        /// <summary>
        /// poziom budynku
        /// </summary>
        protected int level;
        /// <summary>
        /// koszty budynku w złocie
        /// </summary>
        protected int costGold;
        /// <summary>
        /// koszt budynku w żelazie
        /// </summary>
        protected int costIron;
        /// <summary>
        /// koszt budynku w drewnie
        /// </summary>
        protected int costWood;
        /// <summary>
        /// koszt budynku w kameniach
        /// </summary>
        protected int costRock;
        /// <summary>
        /// koszt budynku w glinie
        /// </summary>
        protected int costClay;
        /// <summary>
        /// maksymalny poziom ulepszenia dla wszystkich budynków
        /// </summary>
        public static int MAX_LEVEL = 5;
        // konstruktor
        public Building(int level)
        {
            this.level = level;
            this.costGold = 0;
            this.costIron = 0;
            this.costWood = 0;
            this.costRock = 0;
            this.costClay = 0;
        }
        // settery i gettery
        public int GetLevel()
        {
            return level;
        }
        public int GetCostGold()
        {
            return costGold;
        }
        public int GetCostIron()
        {
            return costIron;
        }
        public int GetCostWood()
        {
            return costWood;
        }
        public int GetCostRock()
        {
            return costRock;
        }
        public int GetCostClay()
        {
            return costClay;
        }
        public void SetCostGold(int price)
        {
            costGold = price;
        }
        public void SetCostIron(int price)
        {
            costIron = price;
        }
        public void SetCostWood(int price)
        {
            costWood = price;
        }
        public void SetCostRock(int price)
        {
            costRock = price;
        }
        public void SetCostClay(int price)
        {
            costClay = price;
        }
        /// <summary>
        /// ustawienie kosztu wszystkich jednocześnie
        /// </summary>
        /// <param name="gold"></param>
        /// <param name="iron"></param>
        /// <param name="wood"></param>
        /// <param name="rock"></param>
        /// <param name="clay"></param>
        public void SetCostAll(int gold, int iron, int wood, int rock, int clay)
        {
            costGold = gold;
            costIron = iron;
            costWood = wood;
            costRock = rock;
            costClay = clay;
        }
        /// <summary>
        /// abstrakcyjna metoda do ulepszania o jeden poziom
        /// </summary>
        public abstract void Upgrade();
        /// <summary>
        /// abstrakcyjna metoda do ulepszania do wybranego poziomu
        /// używana tylko do imperium przeciwników
        /// </summary>
        /// <param name="toLevel"></param>
        public abstract void UpgradeToLevel(int toLevel);
    }
}
