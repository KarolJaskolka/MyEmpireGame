using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa statyczna Łucznik 
    /// (nie jest używana do tworzenia obiektów, 
    /// ponieważ klasa Empire przechowuje tylko ilość wojowników)
    /// zawiera zmienne statyczne informujące o cenie oraz 
    /// posiada jednocześnie atrybuty defensywne i ofensywne
    /// </summary>
    public static class Archer
    {
        /// <summary>
        /// koszt łucznika w złocie
        /// </summary>
        public static int COST_GOLD = 150;
        /// <summary>
        /// koszt łucznika w drewnie
        /// </summary>
        public static int COST_WOOD = 100;
        /// <summary>
        /// atrybuty ofensywne łucznika 
        /// </summary>
        public static int OFFENSIVE = 25;
        /// <summary>
        /// atrybuty defensywne łucznika 
        /// </summary>
        public static int DEFENSIVE = 75;
    }
}
