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
    /// Logika interakcji dla klasy OdliczeniaDoSwiat.xaml
    /// </summary>
    public partial class Odliczenia : Window
    {
        Service service;
        public Odliczenia()
        {
            InitializeComponent();
            SformatujIWyswietlDate();
            service = new Service();
            List<WydarzenieModel> ListaWydarzen = service.Wydarzenia;
            for (int i=0; i<service.Wydarzenia.Count; i++)
            {
                listViewOdliczenia.Items.Add(ListaWydarzen[i]);
            }
        }
        
        private void buttonDodajWydarzenie_Click(object sender, RoutedEventArgs e)
        {
            WydarzenieModel item = new WydarzenieModel();
            DodawanieEdycjaWydarzen dodawanieEdycjaWydarzen = new DodawanieEdycjaWydarzen(item);
            dodawanieEdycjaWydarzen.ShowDialog();
            if (dodawanieEdycjaWydarzen.Success)
            {
                listViewOdliczenia.Items.Add(service.DodajWydarzenie(dodawanieEdycjaWydarzen.element));
            }           
        }

        private void buttonEdytujWydarzenie_Click(object sender, RoutedEventArgs e)
        {
            if (listViewOdliczenia.Items.Count > 0)
            {
                if (listViewOdliczenia.SelectedItems.Count > 0)
                {
                    WydarzenieModel element = (WydarzenieModel)listViewOdliczenia.SelectedItem;
                    WydarzenieModel item = new WydarzenieModel(element);
                    DodawanieEdycjaWydarzen dodawanieEdycjaWydarzen = new DodawanieEdycjaWydarzen(item);
                    dodawanieEdycjaWydarzen.ShowDialog();
                    if (dodawanieEdycjaWydarzen.Success)
                    {
                        int index = listViewOdliczenia.Items.IndexOf(element);
                        listViewOdliczenia.Items.RemoveAt(index);
                        listViewOdliczenia.Items.Insert(index, item);
                        listViewOdliczenia.Items.Refresh();
                        service.EdytujWydarzenie(element);
                    }
                }
                else
                {
                    MessageBox.Show("Proszę wybrać wydarzenie do edycji");
                }
            }
            else
            {
                MessageBox.Show("Brak wydarzeń do edycji");
            }

        }

        private void buttonUsunWydarzenie_Click(object sender, RoutedEventArgs e)
        {
            if (listViewOdliczenia.Items.Count > 0)
            {
                if (listViewOdliczenia.SelectedItems.Count > 0)
                {
                    WydarzenieModel item = (WydarzenieModel)listViewOdliczenia.SelectedItem;
                    service.UsunWydarzenie(item.ID);
                    listViewOdliczenia.Items.Remove(item);
                }
                else
                {
                    MessageBox.Show("Proszę najpierw wybrać wydarzenie do usunięcia");
                }
            }
            else
            {
                MessageBox.Show("Brak wydarzeń do usunięcia");
            }
        }

        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        
    }
}
