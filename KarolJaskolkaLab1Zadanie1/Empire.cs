using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa zawierająca wszystkie informacje o imperium
    /// posiada informacje o zasobach
    /// ilości posiadanych wojowników każdego typu
    /// oraz o budynkach
    /// </summary>
    public class Empire
    {
        /// <summary>
        /// nazwa imperium
        /// </summary>
        private string name;
        /// <summary>
        /// ilość złota w imperium
        /// </summary>
        private int gold;
        /// <summary>
        /// ilość żelaza w imperium
        /// </summary>
        private int iron;
        /// <summary>
        /// ilość drewna w imperium
        /// </summary>
        private int wood;
        /// <summary>
        /// ilość kamienia w imperium
        /// </summary>
        private int rock;
        /// <summary>
        /// ilość gliny w imperium
        /// </summary>
        private int clay;

        // jednostki ofensywne i defensywne 
        // (każdy wojownik posiada jednocześnie oba parametry)

        /// <summary>
        /// ilość rycerzy w imperium
        /// </summary>
        private int knights;
        /// <summary>
        /// ilość łuczników w imperium
        /// </summary>
        private int archers;
        /// <summary>
        /// ilość kawalerzystów w imperium
        /// </summary>
        private int cavalrymen;
        /// <summary>
        /// zmienna informująca czy imperium zostało podbite
        /// </summary>
        private Boolean conquered;
        
        /// <summary>
        /// zamek w imperium
        /// </summary>
        public Castle castle;
        /// <summary>
        /// magazyn w imperium
        /// </summary>
        public Warehouse warehouse;
        /// <summary>
        /// kopalnia żelaza w imperium
        /// </summary>
        public IronMine ironMine;
        /// <summary>
        /// kopalnia złota w imperium
        /// </summary>
        public GoldMine goldMine;
        /// <summary>
        /// tartak w imperium
        /// </summary>
        public Sawmill sawmill;
        /// <summary>
        /// koszary w imperium
        /// </summary>
        public Barrack barrack;
        /// <summary>
        /// kamieniołom w imperium
        /// </summary>
        public Quarry quarry;
        /// <summary>
        /// cegielnia w imperium
        /// </summary>
        public Brickyard brickyard;
        // konstrukor
        public Empire(string name, int gold, int iron, int wood, int rock, int clay, int knights, int archers, int cavalrymen, int buildingsLevel)
        {
            this.name = name;

            this.conquered = false;

            this.gold = gold;
            this.iron = iron;
            this.wood = wood;
            this.rock = rock;
            this.clay = clay;

            this.knights = knights;
            this.archers = archers;
            this.cavalrymen = cavalrymen;
            // utowrzenie budynków o podanym poziomie
            castle = new Castle(buildingsLevel);
            ironMine = new IronMine(buildingsLevel);
            goldMine = new GoldMine(buildingsLevel);
            sawmill = new Sawmill(buildingsLevel);
            barrack = new Barrack(buildingsLevel);
            quarry = new Quarry(buildingsLevel);
            brickyard = new Brickyard(buildingsLevel);
            // sprawdzenie czy podany poziom magazynu nie przekroczy maksymalnego (5)
            if (buildingsLevel < 5) { warehouse = new Warehouse(buildingsLevel + 1); }
                else { warehouse = new Warehouse(5); }

        }

        // settery i gettery

        public string GetName()
        {
            return name;
        }
        public int GetGold()
        {
            return gold;
        }
        public int GetIron()
        {
            return iron;
        }
        public int GetWood()
        {
            return wood;
        }
        public int GetRock()
        {
            return rock;
        }
        public int GetClay()
        {
            return clay;
        }
        public Boolean IsConquered()
        {
            return conquered;
        }
        public void SetGold(int number)
        {
            gold = number;
        }
        public void SetIron(int number)
        {
            iron = number;
        }
        public void SetWood(int number)
        {
            wood = number;
        }
        public void SetRock(int number)
        {
            rock = number;
        }
        public void SetClay(int number)
        {
            clay = number;
        }
        public void SetConquered(Boolean status)
        {
            conquered = status;
        }
        public int GetKnights()
        {
            return knights;
        }
        public int GetArchers()
        {
            return archers;
        }
        public int GetCavalrymen()
        {
            return cavalrymen;
        }
        public void SetKnights(int number)
        {
            knights = number;
        }
        public void SetArchers(int number)
        {
            archers = number;
        }
        public void SetCavalrymen(int number)
        {
            cavalrymen = number;
        }
        /// <summary>
        /// metoda zwracająca siłe ofensywną wojsk w imperium
        /// </summary>
        /// <returns></returns>
        public int GetOffensive()
        {
            return Knight.OFFENSIVE * knights + Archer.OFFENSIVE * archers + Cavalryman.OFFENSIVE * cavalrymen;
        }
        /// <summary>
        /// metoda zwracająca siłe defensywną wojsk w imperium
        /// </summary>
        /// <returns></returns>
        public int GetDefensive()
        {
            return Knight.DEFENSIVE * knights + Archer.DEFENSIVE * archers + Cavalryman.DEFENSIVE * cavalrymen;
        }
        /// <summary>
        /// ulepszenie podanego budynku i pobranie kosztów budowy
        /// </summary>
        /// <param name="name"></param>
        public void UpgradeBuilding(Building name)
        {
            // koszt budowy
            this.SetGold(this.GetGold() - name.GetCostGold());
            this.SetIron(this.GetIron() - name.GetCostIron());
            this.SetWood(this.GetWood() - name.GetCostWood());
            this.SetRock(this.GetRock() - name.GetCostRock());
            this.SetClay(this.GetClay() - name.GetCostClay());
            // wykonanie ulepszenia na obiekcie
            name.Upgrade();

        }
        /// <summary>
        /// aktualizacja zasobów w wiosce
        /// </summary>
        public void UpdateResources()
        {
            // gold update
            this.SetGold(this.GetGold() + this.goldMine.GetGoldPerHour());
            // jeśli przekroczono wielkość magazynu ustawienie na poziom maksymalny
            if (this.GetGold() > this.warehouse.GetCapacity()) this.SetGold(this.warehouse.GetCapacity());
            // iron update
            this.SetIron(this.GetIron() + this.ironMine.GetIronPerHour());
            // jeśli przekroczono wielkość magazynu ustawienie na poziom maksymalny
            if (this.GetIron() > this.warehouse.GetCapacity()) this.SetIron(this.warehouse.GetCapacity());
            // wood update
            this.SetWood(this.GetWood() + this.sawmill.GetWoodPerHour());
            // jeśli przekroczono wielkość magazynu ustawienie na poziom maksymalny
            if (this.GetWood() > this.warehouse.GetCapacity()) this.SetWood(this.warehouse.GetCapacity());
            // rock update
            this.SetRock(this.GetRock() + this.quarry.GetRockPerHour());
            // jeśli przekroczono wielkość magazynu ustawienie na poziom maksymalny
            if (this.GetRock() > this.warehouse.GetCapacity()) this.SetRock(this.warehouse.GetCapacity());
            // clay update
            this.SetClay(this.GetClay() + this.brickyard.GetClayPerHour());
            // jeśli przekroczono wielkość magazynu ustawienie na poziom maksymalny
            if (this.GetClay() > this.warehouse.GetCapacity()) this.SetClay(this.warehouse.GetCapacity());

        }
        /// <summary>
        /// walka pomiędzy wioskami (Boolean aby wyświetlić MessageBox z wynikiem walk)
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static Boolean FIGHT(Empire attacker, Empire defender)
        {
            // zwycięstwo atakujących
            if(attacker.GetOffensive() > defender.GetDefensive())
            {
                // przejęcie zasobów
                attacker.SetGold(attacker.GetGold() + defender.GetGold());
                attacker.SetIron(attacker.GetIron() + defender.GetIron());
                attacker.SetWood(attacker.GetWood() + defender.GetWood());
                attacker.SetRock(attacker.GetRock() + defender.GetRock());
                attacker.SetClay(attacker.GetClay() + defender.GetClay());
                // wyzerowanie zasobów
                defender.SetGold(0);
                defender.SetIron(0);
                defender.SetWood(0);
                defender.SetRock(0);
                defender.SetClay(0);
                // aktualizacja stanu wojsk wygranych
                attacker.SetKnights(attacker.GetKnights() - defender.GetKnights());
                if (attacker.GetKnights() < 0) attacker.SetKnights(0);
                attacker.SetArchers(attacker.GetArchers() - defender.GetArchers());
                if (attacker.GetArchers() < 0) attacker.SetArchers(0);
                attacker.SetCavalrymen(attacker.GetCavalrymen() - defender.GetCavalrymen());
                if (attacker.GetCavalrymen() < 0) attacker.SetCavalrymen(0);
                // wyzerowanie wojsk przegranych
                defender.SetKnights(0);
                defender.SetArchers(0);
                defender.SetCavalrymen(0);

                return true;
            }
            // zwycięstwo broniących
            else
            {
                // aktualizacja stanu wojsk wygranych
                defender.SetKnights(defender.GetKnights() - attacker.GetKnights());
                if (defender.GetKnights() < 0) defender.SetKnights(0);
                defender.SetArchers(defender.GetArchers() - attacker.GetArchers());
                if (defender.GetArchers() < 0) defender.SetArchers(0);
                defender.SetCavalrymen(defender.GetCavalrymen() - attacker.GetCavalrymen());
                if (defender.GetCavalrymen() < 0) defender.SetCavalrymen(0);
                // wyzerowanie wojsk przegranych
                attacker.SetKnights(0);
                attacker.SetArchers(0);
                attacker.SetCavalrymen(0);

                return false;
            }

        }
        /// <summary>
        /// rekrutacja rycerzy (Boolean aby wyświetlić MessageBox czy się powiodło)
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Boolean RecruitKnights(int quantity)
        {
            // sprawdzenie czy jest wystarczająca ilość zasobów
            if (
                this.GetGold() >= (int)(Knight.COST_GOLD * (1 - this.barrack.GetDiscount()) * quantity) &&
                this.GetIron() >= (int)(Knight.COST_IRON * (1 - this.barrack.GetDiscount()) * quantity)
                )
            {
                // dodanie nowych rycerzy
                this.SetKnights(this.GetKnights() + quantity);
                // odjęcie wydanych zasobów
                this.SetGold(this.GetGold() - ((int)(Knight.COST_GOLD * (1 - this.barrack.GetDiscount()))) * quantity);
                this.SetIron(this.GetIron() - ((int)(Knight.COST_IRON * (1 - this.barrack.GetDiscount()))) * quantity);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// rekrutacja łuczników (Boolean aby wyświetlić MessageBox czy się powiodło)
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Boolean RecruitArchers(int quantity)
        {
            // sprawdzenie czy jest wystarczająca ilość zasobów
            if (
                this.GetGold() >= (int)(Archer.COST_GOLD * (1 - this.barrack.GetDiscount()) * quantity) &&
                this.GetWood() >= (int)(Archer.COST_WOOD * (1 - this.barrack.GetDiscount()) * quantity)
                )
            {
                // dodanie nowych łuczników
                this.SetArchers(this.GetArchers() + quantity);
                // odjęcie wydanych zasobów
                this.SetGold(this.GetGold() - ((int)(Archer.COST_GOLD * (1 - this.barrack.GetDiscount()))) * quantity);
                this.SetWood(this.GetWood() - ((int)(Archer.COST_WOOD * (1 - this.barrack.GetDiscount()))) * quantity);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// rekrutacja kawalerzystów (Boolean aby wyświetlić MessageBox czy się powiodło)
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Boolean RecruitCavalrymen(int quantity)
        {
            // sprawdzenie czy jest wystarczająca ilość zasobów
            if (
                this.GetGold() >= (int)(Cavalryman.COST_GOLD * (1 - this.barrack.GetDiscount()) * quantity) &&
                this.GetIron() >= (int)(Cavalryman.COST_IRON * (1 - this.barrack.GetDiscount()) * quantity)
                )
            {
                // dodanie nowych kawalerzystów
                this.SetCavalrymen(this.GetCavalrymen() + quantity);
                // odjęcie wydanych zasobów
                this.SetGold(this.GetGold() - ((int)(Cavalryman.COST_GOLD * (1 - this.barrack.GetDiscount()))) * quantity);
                this.SetIron(this.GetIron() - ((int)(Cavalryman.COST_IRON * (1 - this.barrack.GetDiscount()))) * quantity);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// rekrutacja wszystkich typów wojowników (w celu zwiększenia wojsk przeciwników)
        /// </summary>
        /// <param name="quantityKnights"></param>
        /// <param name="quantityArchers"></param>
        /// <param name="quantityCavalrymen"></param>
        public void RecruitAll(int quantityKnights, int quantityArchers, int quantityCavalrymen)
        {
            // rekrutacja

            // zwracanie typu Boolean tutaj nie ma zbyt dużego sensu,
            // ale było przydatne do wyświetlania MessageBox prędzej

            if (RecruitKnights(quantityKnights)) { }
            if (RecruitArchers(quantityArchers)) { }
            if (RecruitCavalrymen(quantityCavalrymen)) { }
        }

    }
}
