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
using ProjektWPF.Model_danych;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieEdycjaWydarzen.xaml
    /// </summary>
    public partial class DodawanieEdycjaWydarzen : Window
    {
        bool success;
        WydarzenieModel element;
        public DodawanieEdycjaWydarzen(WydarzenieModel model)
        {
            InitializeComponent();
            success = false;
            typCyklu.IsEnabled = false;
            nazwaWydarzenia.DataContext = model;
            datePickerData.DataContext = model;
            comboBoxGodziny.ItemsSource = NumeryCzasowe(24);
            comboBoxGodziny.DataContext = model;
            comboBoxMinuty.ItemsSource = NumeryCzasowe(60);
            comboBoxMinuty.DataContext = model;
            cykl.DataContext = model;
            this.element = model;
        }
        private void buttonPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (element.Nazwa.Length>0)
            {
                success = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nazwa nie może być pusta");
            }
        }
        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void cykl_Checked(object sender, RoutedEventArgs e)
        {
             typCyklu.IsEnabled = true;
        }
        public List<string> NumeryCzasowe(int numer)
        {
            List<string> numery = new List<string>();
            for (int i = 0; i < numer; i++)
            {
                string text = "";
                if (i < 10)
                {
                    text += "0";
                }
                text += i;
                numery.Add(text);
            }
            return numery;
        }
        public bool Success
        {
            get
            {
                return success;
            }
        }
    }
}
