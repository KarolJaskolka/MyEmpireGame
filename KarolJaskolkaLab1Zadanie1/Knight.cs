using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa statyczna Rycerz 
    /// (nie jest używana do tworzenia obiektów, 
    /// ponieważ klasa Empire przechowuje tylko ilość wojowników)
    /// zawiera zmienne statyczne informujące o cenie oraz 
    /// posiada jednocześnie atrybuty defensywne i ofensywne
    /// </summary>
    public static class Knight
    {
        /// <summary>
        /// koszt rycerza w złocie
        /// </summary>
        public static int COST_GOLD = 100;
        /// <summary>
        /// koszt rycerza w żelazie
        /// </summary>
        public static int COST_IRON = 50;
        /// <summary>
        /// atrybuty ofensywne rycerza
        /// </summary>
        public static int OFFENSIVE = 50;
        /// <summary>
        /// atrybuty defensywne rycerza
        /// </summary>
        public static int DEFENSIVE = 25;
    }
}
