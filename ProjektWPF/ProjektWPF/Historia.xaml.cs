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
using ProjektWPF.Czas;
using ProjektWPF.Model_danych;
using ProjektWPF.Serwis;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Pamietnik.xaml
    /// </summary>
    public partial class Historia : Window
    {
        ServiceHistory service;
        public Historia()
        {
            InitializeComponent();
            SformatujIWyswietlDate();
            ZaladujDane();
        }
        private void ZaladujDane()
        {
            service = ServiceHistory.GetInstance();
            List<WydarzenieModel> ListaWydarzen = service.Historia;
            for (int i = 0; i < service.Historia.Count; i++)
            {
                WydarzenieModel element = ListaWydarzen[i];
                listViewPamietnik.Items.Add(ListaWydarzen[i]);
            }
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
            labelCurrentTime.Content = Data.DzienTygodnia[(int)CurrentTime.DayOfWeek] + ", " + data.Dzien + " " +
            Data.NazwaMiesiaca[CurrentTime.Month - 1] + " " + data.Rok + " " + data.Godzina + ":" + data.Minuta + ":" +
            data.Sekunda;
        }
        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
