using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektWPF.Czas;
using ProjektWPF.Model_danych;
using ProjektWPF.Serwis;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service service;
        Data data;
        public MainWindow()
        {
            InitializeComponent();
            SformatujIWyswietlDate();
            ZaladujDane();
        }
        private void AktualizujCzas()
        {

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            labelCurrentTime.Content = DateTime.Now.ToString();
            //tutaj sa funkcje aktualizujace wszystkie rzeczy
            //1 - label z data i czasem
            //2 - aktualizacja listy odliczań

        }
        private void ZaladujDane()
        {
            service = Service.GetInstance();
            List<WydarzenieModel> ListaWydarzen = service.Wydarzenia;
            for (int i = 0; i < service.Wydarzenia.Count; i++)
            {
                WydarzenieModel element = ListaWydarzen[i];
                if (element.DataOdliczania < DateTime.Now)
                {
                    if (element.Cykliczne)
                    {
                        service.ZmienDateDlaOdliczeniaIWpiszDoHistorii(element);
                        service.Oblicz(element);
                        service.EdytujWydarzenie(element);
                    }
                    else
                    {
                        element.Typ = TypOdliczania.Upłynął;
                        service.Oblicz(element);
                        service.EdytujWydarzenie(element);
                        ServiceHistory.GetInstance().DodajdoHistorii(element);
                        service.UsunWydarzenie(element.ID);
                        listWydarzenie.Items.Remove(element);
                    }
                }
                service.Oblicz(element);
                element.PelnaNazwa = element.Nazwa + " " + PozostalyCzas(element.DataOdliczania);
                listWydarzenie.Items.Add(ListaWydarzen[i]);
            }
        }
        private string PozostalyCzas(DateTime czas)
        {
            int dni, godziny, minuty, sekundy;
            DateTime CzasAktualny = DateTime.Now;
            sekundy = 0;
            while (CzasAktualny < czas)
            {
                CzasAktualny = CzasAktualny.AddSeconds(1);
                sekundy++;
            }
            minuty = sekundy / 60;
            godziny = minuty / 60;
            dni = godziny / 24;
            sekundy %= 60;
            minuty %= 60;
            godziny %= 24;
            string PelnaNazwa = "Do wydarzenia zostało ";
            switch (dni)
            {
                case 1:
                    PelnaNazwa += "1 dzień ";
                    break;
                default:
                    PelnaNazwa += dni;
                    PelnaNazwa += " dni ";
                    break;
            }
            PelnaNazwa += godziny;
            PelnaNazwa += " godz ";
            PelnaNazwa += minuty;
            PelnaNazwa += " min ";
            PelnaNazwa += sekundy;
            PelnaNazwa += " sek";
            return PelnaNazwa;
        }
        private void SformatujIWyswietlDate()
        {
            DateTime CurrentTime = DateTime.Now;
            data = new Data();
            data.Dzien = CurrentTime.Day;
            data.Rok = CurrentTime.Year;
            data.Godzina = data.UstawNumer(CurrentTime.Hour);
            data.Minuta = data.UstawNumer(CurrentTime.Minute);
            data.Sekunda = data.UstawNumer(CurrentTime.Second);
            labelCurrentTime.Content = Data.DzienTygodnia[(int)CurrentTime.DayOfWeek] + ", " + data.Dzien + " " +
            Data.NazwaMiesiaca[CurrentTime.Month - 1] + " " + data.Rok + " " + data.Godzina + ":" + data.Minuta + ":" +
            data.Sekunda;
        }
        private void buttonOdliczenia_Click(object sender, RoutedEventArgs e)
        {
            Odliczenia odliczenia = new Odliczenia();
            odliczenia.ShowDialog();
        }

        private void buttonWydarzenia_Click(object sender, RoutedEventArgs e)
        {
            Historia historia = new Historia();
            historia.ShowDialog();
        }
    }
}
