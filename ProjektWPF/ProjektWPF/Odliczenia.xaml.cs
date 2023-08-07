using ProjektWPF.Czas;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy OdliczeniaDoSwiat.xaml
    /// </summary>
    public partial class Odliczenia : Window
    {
        public Odliczenia()
        {
            InitializeComponent();
            SformatujIWyswietlDate();
        }
        private void SformatujIWyswietlDate()
        {
            DateTime CurrentTime = DateTime.Now;
            Data data = new Data();
            data.Dzien = CurrentTime.Day;
            data.Rok = CurrentTime.Year;
            data.Godzina = data.UstawNumer(CurrentTime.Hour);
            data.Minuta = data.UstawNumer(CurrentTime.Minute);
            data.Sekunda = data.UstawNumer(CurrentTime.Second);
            labelCurrentTime.Content = Data.DzienTygodnia[(int)CurrentTime.DayOfWeek - 1] + ", " + data.Dzien + " " +
            Data.NazwaMiesiaca[CurrentTime.Month - 1] + " " + data.Rok + " " + data.Godzina + ":" + data.Minuta + ":" +
            data.Sekunda;
        }
        private void buttonDodajWydarzenie_Click(object sender, RoutedEventArgs e)
        {
            DodawanieEdycjaWydarzen dodawanieEdycjaWydarzen = new DodawanieEdycjaWydarzen();
            dodawanieEdycjaWydarzen.ShowDialog();
        }

        private void buttonEdytujWydarzenie_Click(object sender, RoutedEventArgs e)
        {
            DodawanieEdycjaWydarzen dodawanieEdycjaWydarzen = new DodawanieEdycjaWydarzen();
            dodawanieEdycjaWydarzen.ShowDialog();
        }

        private void buttonUsunWydarzenie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
