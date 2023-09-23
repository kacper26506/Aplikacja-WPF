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
using System.Windows.Threading;
using System.Xml.Linq;
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
        public MainWindow()
        {
            InitializeComponent();
            SformatujWyswietlIAktualizujDate();
            ZaladujDane();
        }
        private void SformatujWyswietlIAktualizujDate()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            Data data = new Data();
            data.Dzien = CurrentTime.Day;
            data.Rok = CurrentTime.Year;
            data.Godzina = data.UstawNumer(CurrentTime.Hour);
            data.Minuta = data.UstawNumer(CurrentTime.Minute);
            data.Sekunda = data.UstawNumer(CurrentTime.Second);
            labelCurrentTime.Content = Data.DzienTygodnia[(int)CurrentTime.DayOfWeek] + ", " + data.Dzien + " " +
            Data.NazwaMiesiaca[CurrentTime.Month - 1] + " " + data.Rok + " " + data.Godzina + ":" + data.Minuta + ":" +
            data.Sekunda;
            //tutaj sa funkcje aktualizujace wszystkie rzeczy
            //1 - label z data i czasem
            //2 - aktualizacja listy odliczań

        }
        public void ZaladujDane()
        {
            service = Service.GetInstance();
            var wydarzenia = service.Wydarzenia;
            wydarzenia = service.AktualizujWydarzenia(wydarzenia);
            listWydarzenie.ItemsSource = wydarzenia;
        } 
        private void buttonOdliczenia_Click(object sender, RoutedEventArgs e)
        {
            Odliczenia odliczenia = new Odliczenia();
            odliczenia.ShowDialog();
            // Tu będzie trzeba odświeżyć listę w głównym oknie
        }
        private void buttonWydarzenia_Click(object sender, RoutedEventArgs e)
        {
            Historia historia = new Historia();
            historia.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var wydarzenia = service.Wydarzenia;
            wydarzenia = service.AktualizujWydarzenia(wydarzenia);
            listWydarzenie.ItemsSource = wydarzenia;
        }
    }
}
