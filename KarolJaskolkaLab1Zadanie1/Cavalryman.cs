using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa statyczna Kawalerzysta
    /// (nie jest używana do tworzenia obiektów, 
    /// ponieważ klasa Empire przechowuje tylko ilość wojowników)
    /// zawiera zmienne statyczne informujące o cenie oraz 
    /// posiada jednocześnie atrybuty defensywne i ofensywne
    /// </summary>
    public static class Cavalryman
    {
        /// <summary>
        /// koszt kawalerzysty w złocie
        /// </summary>
        public static int COST_GOLD = 200;
        /// <summary>
        /// koszt kawalerzysty w żelazie
        /// </summary>
        public static int COST_IRON = 150;
        /// <summary>
        /// atrybuty ofensywne kawalerzysty
        /// </summary>
        public static int OFFENSIVE = 100;
        /// <summary>
        /// atrybuty defensywne kawalerzysty
        /// </summary>
        public static int DEFENSIVE = 50;
    }
}
