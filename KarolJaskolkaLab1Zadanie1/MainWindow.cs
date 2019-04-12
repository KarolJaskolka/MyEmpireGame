using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// author : Karol Jaskółka

namespace KarolJaskolkaLab1Zadanie1
{
    /// <summary>
    /// klasa okna programu
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// numer dnia gry
        /// </summary>
        private int day = 1;
        /// <summary>
        /// numer godziny gry
        /// </summary>
        private int hour = 1;
        /// <summary>
        /// wioska gracza
        /// </summary>
        private Empire myEmpire = new Empire("Your Empire",1000, 1000, 1000, 1000, 1000, 0, 0, 0, 0);
        /// <summary>
        /// przeciwna wioska nr1
        /// </summary>
        private Empire empire1 = new Empire("Small Empire", 2000, 5000, 2000, 2000, 2000, 6, 6, 0, 1);
        /// <summary>
        /// przeciwna wioska nr2
        /// </summary>
        private Empire empire2 = new Empire("Medium Empire", 10000, 10000, 20000, 10000, 10000, 20, 0, 15, 2);
        /// <summary>
        /// przeciwna wioska nr3
        /// </summary>
        private Empire empire3 = new Empire("Large Empire", 125000, 75000, 75000, 75000, 75000, 175, 400, 50, 4);

        public MainWindow()
        {
            InitializeComponent();
            // wyłączenie przycisków w celu ustawienia ścieżki rozgrywki
            EnableButtons();
            // ukrycie wioski gracz na mapie
            pictureBoxCastleMap.Visible = false;
            // ukrycie napisu nad wioską gracza na mapie
            labelYou.Visible = false;
            // ustawienie kolorów paneli
            SetPanelsColors();
            // ustawienie napisów na ekranie
            SetLabelsWarriorsStatus();
            SetLabelsWarriorsCost();
            SetLabelsWarriorsPower();
            LabelsEmpiresUpdate();
            LabelsBuildingsCostUpdate();
        }
        /// <summary>
        /// funkcja ustawiająca kolory paneli
        /// </summary>
        private void SetPanelsColors()
        {
            panelRight.BackColor = Color.FromArgb(35, 155, 111);
            panelLeft.BackColor = Color.FromArgb(35, 155, 111);
            panelCenter.BackColor = Color.FromArgb(33, 175, 123);
            panelTime.BackColor = Color.FromArgb(216, 174, 21);
            panelBottom.BackColor = Color.FromArgb(19, 107, 71);
            panelResources.BackColor = Color.FromArgb(242, 221, 140);
            panelStats.BackColor = Color.FromArgb(226, 201, 106);
            panelHint.BackColor = Color.FromArgb(230, 233, 239);
        }

        /// <summary>
        /// funkcja wyłączająca przyciski
        /// </summary>
        private void EnableButtons()
        {
            buttonBarrackBuild.Enabled = false;
            buttonSawmillBuild.Enabled = false;
            buttonIronMineBuild.Enabled = false;
            buttonGoldMineBuild.Enabled = false;
            buttonCastleBuild.Enabled = false;
            buttonQuarryBuild.Enabled = false;
            buttonBrickyardBuild.Enabled = false;
            buttonBarrackUpgrade.Enabled = false;
            buttonSawmillUpgrade.Enabled = false;
            buttonIronMineUpgrade.Enabled = false;
            buttonGoldMineUpgrade.Enabled = false;
            buttonQuarryUpgrade.Enabled = false;
            buttonBrickyardUpgrade.Enabled = false;
            buttonWarehouseUpgrade.Enabled = false;
            buttonRecruitKnight.Enabled = false;
            buttonRecruitArcher.Enabled = false;
            buttonRecruitCavalryman.Enabled = false;
            buttonAttackEmpire1.Enabled = false;
            buttonAttackEmpire2.Enabled = false;
            buttonAttackEmpire3.Enabled = false;
        }
        /// <summary>
        /// funkcja aktualizująca liczbe wojowników gracza na ekranie
        /// </summary>
        private void SetLabelsWarriorsStatus()
        {
            labelQuantityKnights.Text = myEmpire.GetKnights().ToString();
            labelQuantityArchers.Text = myEmpire.GetArchers().ToString();
            labelQuantityCavalrymen.Text = myEmpire.GetCavalrymen().ToString();
        }
        /// <summary>
        /// funkcja aktualizująca liczbe wojowników w przeciwnych wioskach na ekranie
        /// </summary>
        private void LabelsEmpiresUpdate()
        {
            labelOffEmpire1.Text = empire1.GetOffensive().ToString();
            labelOffEmpire2.Text = empire2.GetOffensive().ToString();
            labelOffEmpire3.Text = empire3.GetOffensive().ToString();
            labelDefEmpire1.Text = empire1.GetDefensive().ToString();
            labelDefEmpire2.Text = empire2.GetDefensive().ToString();
            labelDefEmpire3.Text = empire3.GetDefensive().ToString();
        }
        /// <summary>
        /// funkcja aktualizująca koszt wytworzenia wojowników na ekranie
        /// </summary>
        private void SetLabelsWarriorsCost()
        {
            labelKnightGold.Text = ((int)(Knight.COST_GOLD * (1 - myEmpire.barrack.GetDiscount()))).ToString();
            labelKnightIron.Text = ((int)(Knight.COST_IRON * (1 - myEmpire.barrack.GetDiscount()))).ToString();
            labelArcherGold.Text = ((int)(Archer.COST_GOLD * (1 - myEmpire.barrack.GetDiscount()))).ToString();
            labelArcherWood.Text = ((int)(Archer.COST_WOOD * (1 - myEmpire.barrack.GetDiscount()))).ToString();
            labelCavalrymanGold.Text = ((int)(Cavalryman.COST_GOLD * (1 - myEmpire.barrack.GetDiscount()))).ToString();
            labelCavalrymanIron.Text = ((int)(Cavalryman.COST_IRON * (1 - myEmpire.barrack.GetDiscount()))).ToString();
        }
        /// <summary>
        /// funkcja aktualizująca koszt ulepszeń budynków na ekranie
        /// </summary>
        private void LabelsBuildingsCostUpdate()
        {
            // Castle
            labelCastleGold.Text = myEmpire.castle.GetCostGold().ToString();
            labelCastleIron.Text = myEmpire.castle.GetCostIron().ToString();
            labelCastleWood.Text = myEmpire.castle.GetCostWood().ToString();
            labelCastleRock.Text = myEmpire.castle.GetCostRock().ToString();
            labelCastleClay.Text = myEmpire.castle.GetCostClay().ToString();
            // Warehouse
            labelWarehouseGold.Text = myEmpire.warehouse.GetCostGold().ToString();
            labelWarehouseIron.Text = myEmpire.warehouse.GetCostIron().ToString();
            labelWarehouseWood.Text = myEmpire.warehouse.GetCostWood().ToString();
            labelWarehouseRock.Text = myEmpire.warehouse.GetCostRock().ToString();
            labelWarehouseClay.Text = myEmpire.warehouse.GetCostClay().ToString();
            // Barrack
            labelBarrackGold.Text = myEmpire.barrack.GetCostGold().ToString();
            labelBarrackIron.Text = myEmpire.barrack.GetCostIron().ToString();
            labelBarrackWood.Text = myEmpire.barrack.GetCostWood().ToString();
            labelBarrackRock.Text = myEmpire.barrack.GetCostRock().ToString();
            labelBarrackClay.Text = myEmpire.barrack.GetCostClay().ToString();
            // Brickyard
            labelBrickyardGold.Text = myEmpire.brickyard.GetCostGold().ToString();
            labelBrickyardIron.Text = myEmpire.brickyard.GetCostIron().ToString();
            labelBrickyardWood.Text = myEmpire.brickyard.GetCostWood().ToString();
            labelBrickyardRock.Text = myEmpire.brickyard.GetCostRock().ToString();
            labelBrickyardClay.Text = myEmpire.brickyard.GetCostClay().ToString();
            // Quarry
            labelQuarryGold.Text = myEmpire.quarry.GetCostGold().ToString();
            labelQuarryIron.Text = myEmpire.quarry.GetCostIron().ToString();
            labelQuarryWood.Text = myEmpire.quarry.GetCostWood().ToString();
            labelQuarryRock.Text = myEmpire.quarry.GetCostRock().ToString();
            labelQuarryClay.Text = myEmpire.quarry.GetCostClay().ToString();
            // GoldMine
            labelGoldMineGold.Text = myEmpire.goldMine.GetCostGold().ToString();
            labelGoldMineIron.Text = myEmpire.goldMine.GetCostIron().ToString();
            labelGoldMineWood.Text = myEmpire.goldMine.GetCostWood().ToString();
            labelGoldMineRock.Text = myEmpire.goldMine.GetCostRock().ToString();
            labelGoldMineClay.Text = myEmpire.goldMine.GetCostClay().ToString();
            // IronMine
            labelIronMineGold.Text = myEmpire.ironMine.GetCostGold().ToString();
            labelIronMineIron.Text = myEmpire.ironMine.GetCostIron().ToString();
            labelIronMineWood.Text = myEmpire.ironMine.GetCostWood().ToString();
            labelIronMineRock.Text = myEmpire.ironMine.GetCostRock().ToString();
            labelIronMineClay.Text = myEmpire.ironMine.GetCostClay().ToString();
            // Sawmill
            labelSawmillGold.Text = myEmpire.sawmill.GetCostGold().ToString();
            labelSawmillIron.Text = myEmpire.sawmill.GetCostIron().ToString();
            labelSawmillWood.Text = myEmpire.sawmill.GetCostWood().ToString();
            labelSawmillRock.Text = myEmpire.sawmill.GetCostRock().ToString();
            labelSawmillClay.Text = myEmpire.sawmill.GetCostClay().ToString();
        }
        /// <summary>
        /// funkcja wyświetlająca atrybuty ofensywne i defensywne wojowników na ekranie
        /// </summary>
        private void SetLabelsWarriorsPower()
        {
            labelOffKnight.Text = Knight.OFFENSIVE.ToString();
            labelOffArcher.Text = Archer.OFFENSIVE.ToString();
            labelOffCavalryman.Text = Cavalryman.OFFENSIVE.ToString();

            labelDefKnight.Text = Knight.DEFENSIVE.ToString();
            labelDefArcher.Text = Archer.DEFENSIVE.ToString();
            labelDefCavalryman.Text = Cavalryman.DEFENSIVE.ToString();
        }
        /// <summary>
        /// funkcja aktualizująca zasoby wszystkich wiosek wyświetlanych na ekranie
        /// </summary>
        private void LabelResourcesUpdate()
        {
            // MyEmpire
            labelGold.Text = myEmpire.GetGold().ToString();
            labelIron.Text = myEmpire.GetIron().ToString();
            labelWood.Text = myEmpire.GetWood().ToString();
            labelRock.Text = myEmpire.GetRock().ToString();
            labelClay.Text = myEmpire.GetClay().ToString();
            // Empire1
            labelGoldEmpire1.Text = empire1.GetGold().ToString();
            labelIronEmpire1.Text = empire1.GetIron().ToString();
            labelWoodEmpire1.Text = empire1.GetWood().ToString();
            labelRockEmpire1.Text = empire1.GetRock().ToString();
            labelClayEmpire1.Text = empire1.GetClay().ToString();
            // Empire2
            labelGoldEmpire2.Text = empire2.GetGold().ToString();
            labelIronEmpire2.Text = empire2.GetIron().ToString();
            labelWoodEmpire2.Text = empire2.GetWood().ToString();
            labelRockEmpire2.Text = empire2.GetRock().ToString();
            labelClayEmpire2.Text = empire2.GetClay().ToString();
            // Empire3
            labelGoldEmpire3.Text = empire3.GetGold().ToString();
            labelIronEmpire3.Text = empire3.GetIron().ToString();
            labelWoodEmpire3.Text = empire3.GetWood().ToString();
            labelRockEmpire3.Text = empire3.GetRock().ToString();
            labelClayEmpire3.Text = empire3.GetClay().ToString();
        }
        /// <summary>
        /// funkcja aktualizująca pojemność magazynu na ekranie
        /// </summary>
        private void LabelMaxResourcesUpdate()
        {
            labelGoldMax.Text = myEmpire.warehouse.GetCapacity().ToString();
            labelIronMax.Text = myEmpire.warehouse.GetCapacity().ToString();
            labelWoodMax.Text = myEmpire.warehouse.GetCapacity().ToString();
            labelRockMax.Text = myEmpire.warehouse.GetCapacity().ToString();
            labelClayMax.Text = myEmpire.warehouse.GetCapacity().ToString();
        }
        /// <summary>
        /// funkcja aktualizująca moc ofensywną i defensywną wioski gracza
        /// </summary>
        private void LabelArmyPowerUpdate()
        {
            labelOffensivePower.Text = myEmpire.GetOffensive().ToString();
            labelDefensivePower.Text = myEmpire.GetDefensive().ToString();
        }
        /// <summary>
        /// funkcja aktualizująca progressBary z zasobami na ekranie
        /// </summary>
        private void ProgressBarsUpdate()
        {
            progressBarGold.Value = myEmpire.GetGold();
            progressBarIron.Value = myEmpire.GetIron();
            progressBarWood.Value = myEmpire.GetWood();
            progressBarRock.Value = myEmpire.GetRock();
            progressBarClay.Value = myEmpire.GetClay();
        }
        /// <summary>
        /// funkcja aktualizująca maksymalną wartość progressBarów z zasobami na ekranie
        /// </summary>
        private void ProgressBarsMaxUpdate()
        {
            
            progressBarGold.Maximum = myEmpire.warehouse.GetCapacity();
            progressBarIron.Maximum = myEmpire.warehouse.GetCapacity();
            progressBarWood.Maximum = myEmpire.warehouse.GetCapacity();
            progressBarRock.Maximum = myEmpire.warehouse.GetCapacity();
            progressBarClay.Maximum = myEmpire.warehouse.GetCapacity();
        }
        /// <summary>
        /// przycisk start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // określenie częstotliwości timera
            timerCounter.Interval = 1000;
            // start timera
            timerCounter.Start();
            // aktywacja przycisku do budowania zamku
            buttonCastleBuild.Enabled = true;
            // ustawienie zasobów na ekranie
            LabelResourcesUpdate();
            // ustawienie pojemności magazynu na ekranie
            LabelMaxResourcesUpdate();
            // ukrycie przycisku start
            buttonStart.Visible = false;
            // ustawienie dalszych wskazówek na ekranie
            labelHint.Text = "Build a Castle to unblock other buildings";
            // ustawienie progressBar na ekranie
            ProgressBarsUpdate();
            ProgressBarsMaxUpdate();
        }
        /// <summary>
        /// funkcja przeprowadzająca działania związane z tyknięciem zegara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCounter_Tick(object sender, EventArgs e)
        {
            // warunek kończący rozgrywkę
            if(empire1.IsConquered() == true && empire2.IsConquered() == true && empire3.IsConquered() == true)
            {
                // zatrzymanie zegara
                timerCounter.Stop();
                // wyświetlenie gratulacji na ekranie
                MessageBox.Show("Congratulations you won ! World belongs to you !");
                // zamknięcie aplikacji
                Close();
            }

            // zwiększenie godziny o 1 
            hour++;
            // aktualizacja godziny wyświetlanej na ekranie
            labelHour.Text = hour.ToString();

            // aktualizacja zasobów wiosek w czasie

            myEmpire.UpdateResources();
            empire1.UpdateResources();
            empire2.UpdateResources();
            empire3.UpdateResources();

            // aktualizacja zasobów wiosek na ekranie
            LabelResourcesUpdate();

            // aktualizacja stanu wojsk przeciwników co 24h:
            if (hour == 1)
            {
                if (empire1.IsConquered() == false)
                {
                    empire1.RecruitAll(1, 1, 0);
                }
                if (empire2.IsConquered() == false)
                {
                    empire2.RecruitAll(3, 0, 1);
                }
                if (empire3.IsConquered() == false)
                {
                    empire3.RecruitAll(5, 10, 5);
                }
                // wyświetlenie na ekranie
                LabelsEmpiresUpdate();
            }


            // aktualizacja liczby dni gdy miną 24 godziny
            if (hour == 24)
            {
                // wyzerowanie liczby godzin
                hour = 0;
                // zwiększenie dni o 1
                day++;
                // aktualizacja wyświetlanych na ekranie danych dotyczących czasu
                labelHour.Text = hour.ToString();
                labelDay.Text = day.ToString();
                // Wydarzenia w trakcie rozgrywki

                // ataki :

                // ostrzeżenie przed atakiem
                if (day == 4 && empire1.IsConquered() == false)
                {
                    labelHint.Text = empire1.GetName() + " is going to attack your village tomorrow !";
                }
                // atak empire1 na gracza jeśli prędzej nie zostało podbite
                if (day == 5 && empire1.IsConquered() == false)
                {
                    // walka
                    if (Empire.FIGHT(empire1,myEmpire))
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire1.GetName() + " attacked your village, killed your warriors and stole your resources");
                        
                    }
                    else
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire1.GetName() +  " attacked your village but your warriors repulsed their attack");
                        
                    }
                    // aktualizacja stanu wojsk i zasobów
                    LabelResourcesUpdate();
                    SetLabelsWarriorsStatus();
                    LabelArmyPowerUpdate();
                    LabelsEmpiresUpdate();
                    labelHint.Text = "Develop your empire to conquer other settlements and protect your own";

                }
                // ostrzeżenie przed atakiem
                if (day == 9 && empire2.IsConquered() == false)
                {
                    labelHint.Text = empire2.GetName() + " is going to attack your village tomorrow!";
                }
                // atak empire2 na gracza jeśli prędzej nie zostało podbite
                if (day == 10 && empire2.IsConquered() == false)
                {
                    // walka
                    if (Empire.FIGHT(empire2, myEmpire))
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire2.GetName() + " attacked your village, killed your warriors and stole your resources");

                    }
                    else
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire2.GetName() + " attacked your village but your warriors repulsed their attack");
                        
                    }
                    // aktualizacja stanu wojsk i zasobów
                    LabelResourcesUpdate();
                    SetLabelsWarriorsStatus();
                    LabelArmyPowerUpdate();
                    LabelsEmpiresUpdate();
                    labelHint.Text = "Develop your empire to conquer other settlements and protect your own";

                }
                // ostrzeżenie przed atakiem
                if (day == 13 && empire3.IsConquered() == false)
                {
                    labelHint.Text = empire3.GetName() + " is going to attack your village at day 15 !";
                }
                // atak empire3 na gracza jeśli prędzej nie zostało podbite
                if (day == 15 && empire3.IsConquered() == false)
                {
                    // walka
                    if (Empire.FIGHT(empire3, myEmpire))
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire3.GetName() + " attacked your village, killed your warriors and stole your resources");

                    }
                    else
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire3.GetName() +  " attacked your village but your warriors repulsed their attack");
                       
                    }
                    // aktualizacja stanu wojsk i zasobów
                    LabelResourcesUpdate();
                    SetLabelsWarriorsStatus();
                    LabelArmyPowerUpdate();
                    LabelsEmpiresUpdate();
                    labelHint.Text = "Develop your empire to conquer other settlements and protect your own";
                }
                // ostrzeżenie przed atakiem
                if (day == 18 && empire3.IsConquered() == false)
                {
                    labelHint.Text = empire3.GetName() + " is going to attack your village at day 20 !";
                }
                // informacja o zmianie zamiarów
                if (day == 19 && empire3.IsConquered() == true)
                {
                    labelHint.Text = empire3.GetName() + " abandoned an idea to attack your village";
                }
                // ponowny atak empire3 na gracza jeśli prędzej nie zostało podbite
                if (day == 20 && empire3.IsConquered() == false)
                {
                    // walka
                    if (Empire.FIGHT(empire3, myEmpire))
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire3.GetName() + " attacked your village, killed your warriors and stole your resources");

                    }
                    else
                    {
                        // informacja o rezultacie walki
                        MessageBox.Show(empire3.GetName() + " attacked your village but your warriors repulsed their attack");

                    }
                    // aktualizacja stanu wojsk i zasobów
                    LabelResourcesUpdate();
                    SetLabelsWarriorsStatus();
                    LabelArmyPowerUpdate();
                    LabelsEmpiresUpdate();
                    labelHint.Text = "Develop your empire to conquer other settlements and protect your own";
                }

            }
            if (day == 20) { labelHint.Text = "Develop your empire to conquer other settlements and protect your own"; }
            myEmpire.UpdateResources();
            // aktualizacja progressBar na ekranie
            ProgressBarsUpdate();
        }
        /// <summary>
        /// funkcja sprawdzająca czy stać użytkownika na wybudowanie budynku
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Boolean isAffordable(Building name, Empire village)
        {
            // warunek sprawdzający
            if(village.GetGold() >= name.GetCostGold() && village.GetIron() >= name.GetCostIron() && village.GetWood() >= name.GetCostWood() &&
                village.GetRock() >= name.GetCostRock() && village.GetClay() >= name.GetCostClay())
            {
                return true;
            }
            else
            {
                // poinformowanie gracza o braku środków wymaganych do ulepszenia
                MessageBox.Show("You do not have enough resources");
                return false;
            } 
        }

        /// <summary>
        /// przycisk budowy zamku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCastleBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.castle,myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.castle);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelCastleLevel.Text = myEmpire.castle.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Build a Quarry to start rock production";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonCastleBuild.Enabled = false;
                buttonQuarryBuild.Enabled = true;
                pictureBoxCastleMap.Visible = true;
                labelYou.Visible = true;

            }
        }
        /// <summary>
        /// przycisk budowy kamieniołomu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuarryBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.quarry, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza 
                myEmpire.UpgradeBuilding(myEmpire.quarry);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie

                labelQuarryLevel.Text = myEmpire.quarry.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Build a Gold Mine to start gold production";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonQuarryBuild.Enabled = false;
                buttonQuarryUpgrade.Enabled = true;
                buttonGoldMineBuild.Enabled = true;
            }


        }
        /// <summary>
        /// przycisk budowy kopalni złota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoldMineBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.goldMine, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.goldMine);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelGoldMineLevel.Text = myEmpire.goldMine.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Build a Iron Mine to start iron production";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonGoldMineBuild.Enabled = false;
                buttonGoldMineUpgrade.Enabled = true;
                buttonIronMineBuild.Enabled = true;

            }


        }
        /// <summary>
        /// przycisk budowy kopalni żelaza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIronMineBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.ironMine, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.ironMine);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelIronMineLevel.Text = myEmpire.ironMine.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Build a Sawmill to start wood production";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonIronMineBuild.Enabled = false;
                buttonIronMineUpgrade.Enabled = true;
                buttonSawmillBuild.Enabled = true;
            }
        }
        /// <summary>
        /// przycisk budowy tartaku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSawmillBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.sawmill, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.sawmill);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie

                labelSawmillLevel.Text = myEmpire.sawmill.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Build a Brickyard to start clay production";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonSawmillBuild.Enabled = false;
                buttonSawmillUpgrade.Enabled = true;
                buttonBrickyardBuild.Enabled = true;
            }
        }
        /// <summary>
        /// przycisk budowy cegielni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrickyardBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.brickyard, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.brickyard);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelBrickyardLevel.Text = myEmpire.brickyard.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Wait for resources and build Barrack to recruit Warriors";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonBrickyardBuild.Enabled = false;
                buttonBrickyardUpgrade.Enabled = true;
                buttonBarrackBuild.Enabled = true;
            }
        }
        /// <summary>
        /// przycisk budowy koszar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBarrackBuild_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może wybudować budynek
            if (isAffordable(myEmpire.barrack, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.barrack);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelBarrackLevel.Text = myEmpire.barrack.GetLevel().ToString();
                // aktualizacja wskazówki
                labelHint.Text = "Develop your empire to conquer other settlements and protect your own";
                // aktualizacja stanów przycisków w celu ustawienia rozgrywki
                buttonBarrackBuild.Enabled = false;
                buttonBarrackUpgrade.Enabled = true;
                buttonWarehouseUpgrade.Enabled = true;
                // umożliwienie rekrutowania wojowników
                buttonRecruitKnight.Enabled = true;
                buttonRecruitArcher.Enabled = true;
                buttonRecruitCavalryman.Enabled = true;
                // umożliwienie ataku na inne wioski przez gracza
                buttonAttackEmpire1.Enabled = true;
                buttonAttackEmpire2.Enabled = true;
                buttonAttackEmpire3.Enabled = true;
            }

        }
        /// <summary>
        /// przycisk ulepszenia kopalni złota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoldMineUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.goldMine, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.goldMine);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelGoldMineLevel.Text = myEmpire.goldMine.GetLevel().ToString();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelGoldMineLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonGoldMineUpgrade.Enabled = false;
                }
            }

        }
        /// <summary>
        /// przycisk ulepszenia kopalni żelaża
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIronMineUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.ironMine, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.ironMine);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelIronMineLevel.Text = myEmpire.ironMine.GetLevel().ToString();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelIronMineLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonIronMineUpgrade.Enabled = false;
                }
            }


        }
        /// <summary>
        /// przycisk ulepszenia tartaku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSawmillUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.sawmill, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.sawmill);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelSawmillLevel.Text = myEmpire.sawmill.GetLevel().ToString();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelSawmillLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonSawmillUpgrade.Enabled = false;
                }
            }


        }
        /// <summary>
        /// przycisk ulepszenia koszar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBarrackUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.barrack, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.barrack);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelBarrackLevel.Text = myEmpire.barrack.GetLevel().ToString();
                SetLabelsWarriorsCost();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelBarrackLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonBarrackUpgrade.Enabled = false;
                }
            }


        }
        /// <summary>
        /// przycisk ulepszenia magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWarehouseUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.warehouse, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.warehouse);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelWarehouseLevel.Text = myEmpire.warehouse.GetLevel().ToString();
                // aktualizacja maksymalnych zasobów na ekranie i progressBar
                LabelMaxResourcesUpdate();
                ProgressBarsMaxUpdate();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelWarehouseLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonWarehouseUpgrade.Enabled = false;
                }
            }


        }
        /// <summary>
        /// przycisk ulepszenia kamieniołomu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuarryUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.quarry, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.quarry);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelQuarryLevel.Text = myEmpire.quarry.GetLevel().ToString();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelQuarryLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonQuarryUpgrade.Enabled = false;
                }
            }

        }
        /// <summary>
        /// przycisk ulepszenia cegielni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrickyardUpgrade_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy użytkownik może ulepszyć budynek
            if (isAffordable(myEmpire.brickyard, myEmpire))
            {
                // wywołanie funkcji ulepszenia budynku z wioski gracza
                myEmpire.UpgradeBuilding(myEmpire.brickyard);
                // aktualizacja  zasobów na ekranie
                LabelResourcesUpdate();
                LabelsBuildingsCostUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
                // aktualizacja poziomu budynku na ekranie
                labelBrickyardLevel.Text = myEmpire.brickyard.GetLevel().ToString();
                // dezaktywacja ulepszeń bo uzyskaniu maksymalnego poziomu
                if (Int32.Parse(labelBrickyardLevel.Text) == Building.MAX_LEVEL)
                {
                    buttonBrickyardUpgrade.Enabled = false;
                }
            }

        }
        /// <summary>
        /// przycisk rekrutacji rycerzy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitKnight_Click(object sender, EventArgs e)
        {
            // rekrutacja rycerzy w ilości podanej przez gracza o ile to możliwe
            if (myEmpire.RecruitKnights(Convert.ToInt32(numericUpDownKnights.Value)))
            {
                // aktualizacja stanu wojska i zasobów
                labelQuantityKnights.Text = myEmpire.GetKnights().ToString();
                LabelResourcesUpdate();
                LabelArmyPowerUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
            }
            else
            {
                // informacja o braku surowców
                MessageBox.Show("You need more resources");
            }

        }
        /// <summary>
        /// przycisk rekrutacji łuczników
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitArcher_Click(object sender, EventArgs e)
        {
            // rekrutacja łuczników w ilości podanej przez gracza o ile to możliwe
            if (myEmpire.RecruitArchers(Convert.ToInt32(numericUpDownArchers.Value)))
            {
                // aktualizacja stanu wojska i zasobów
                labelQuantityArchers.Text = myEmpire.GetArchers().ToString();
                LabelResourcesUpdate();
                LabelArmyPowerUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
            }
            else
            {
                // informacja o braku surowców
                MessageBox.Show("You need more resources");
            }
        }
        /// <summary>
        /// przycisk rekrutacji kawalerzystów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitCavalryman_Click(object sender, EventArgs e)
        {
            // rekrutacja kawlerzystów w ilości podanej przez gracza o ile to możliwe
            if (myEmpire.RecruitCavalrymen(Convert.ToInt32(numericUpDownCavalrymen.Value)))
            {
                // aktualizacja stanu wojska i zasobów
                labelQuantityCavalrymen.Text = myEmpire.GetCavalrymen().ToString();
                LabelResourcesUpdate();
                LabelArmyPowerUpdate();
                // ustawienie progressBar na ekranie
                ProgressBarsUpdate();
            }
            else
            {
                // informacja o braku surowców
                MessageBox.Show("You need more resources");
            }

        }
        /// <summary>
        /// przycisk ataku na empire1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttackEmpire1_Click(object sender, EventArgs e)
        {
            // atak na empire1 przez gracza
            if (Empire.FIGHT(myEmpire, empire1))
            {
                // informacja o wyniku walki
                MessageBox.Show("You won the fight! Rivalry empire conquered!");
                empire1.SetConquered(true);
            }
            else
            {
                // informacja o wyniku walki
                MessageBox.Show("You lost the fight! All your warriors died!");
            }
            // aktualizacja stanu wojsk oraz zasobów w obu wioskach
            LabelResourcesUpdate();
            SetLabelsWarriorsStatus();
            LabelArmyPowerUpdate();
            LabelsEmpiresUpdate();
            // ustawienie progressBar na ekranie
            ProgressBarsUpdate();
        }
        /// <summary>
        /// przycisk ataku na empire2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttackEmpire2_Click(object sender, EventArgs e)
        {
            // atak na empire2 przez gracza
            if (Empire.FIGHT(myEmpire, empire2))
            {
                // informacja o wyniku walki
                MessageBox.Show("You won the fight! Rivalry empire conquered!");
                empire2.SetConquered(true);
            }
            else
            {
                // informacja o wyniku walki
                MessageBox.Show("You lost the fight! All your warriors died!");
            }
            // aktualizacja stanu wojsk oraz zasobów w obu wioskach
            LabelResourcesUpdate();
            SetLabelsWarriorsStatus();
            LabelArmyPowerUpdate();
            LabelsEmpiresUpdate();
            // ustawienie progressBar na ekranie
            ProgressBarsUpdate();
        }
        /// <summary>
        /// przycisk ataku na empire3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttackEmpire3_Click(object sender, EventArgs e)
        {
            // atak na empire3 przez gracza
            if (Empire.FIGHT(myEmpire, empire3))
            {
                // informacja o wyniku walki
                MessageBox.Show("You won the fight! Rivalry empire conquered!");
                empire3.SetConquered(true);
            }
            else
            {
                // informacja o wyniku walki
                MessageBox.Show("You lost the fight! All your warriors died!");
            }
            // aktualizacja stanu wojsk oraz zasobów w obu wioskach
            LabelResourcesUpdate();
            SetLabelsWarriorsStatus();
            LabelArmyPowerUpdate();
            LabelsEmpiresUpdate();
            // ustawienie progressBar na ekranie
            ProgressBarsUpdate();
        }
    }
}
