using System;
using System.Collections.Generic;
using System.IO;
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
using ProjektWPF.Serwis;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieEdycjaWydarzen.xaml
    /// </summary>
    public partial class DodawanieEdycjaWydarzen : Window
    {
        bool success;
        public WydarzenieModel element;
        public DodawanieEdycjaWydarzen(WydarzenieModel model)
        {
            InitializeComponent();
            success = false;
            nazwaWydarzenia.DataContext = model;
            datePickerData.DataContext = model;
            comboBoxGodziny.ItemsSource = NumeryCzasowe(24);
            comboBoxGodziny.DataContext = model;
            comboBoxMinuty.ItemsSource = NumeryCzasowe(60);
            comboBoxMinuty.DataContext = model;
            cykl.DataContext = model;
            typCyklu.IsEnabled = model.Cykliczne;
            typCyklu.DataContext = model;
            model.CzyCykliczne = model.CzyCykliczne;
            imageWydarzenia.DataContext = model;
            this.element = model;
        }
        private void buttonPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (element.Nazwa.Length == 0)
            { 
                MessageBox.Show("Nazwa nie może być pusta");
                return;
            }
            if (cykl.IsChecked.HasValue && cykl.IsChecked.Value)
            {
                switch (typCyklu.SelectedIndex)
                {
                    case 0:
                        element.Typ = TypOdliczania.Rok;
                        break;
                    case 1:
                        element.Typ = TypOdliczania.Kwartał;
                        break;
                    case 2:
                        element.Typ = TypOdliczania.Miesiąc;
                        break;
                    case 3:
                        element.Typ = TypOdliczania.Tydzień;
                        break;
                    case 4:
                        element.Typ = TypOdliczania.Dzień;
                        break;
                    default:
                        element.Typ = TypOdliczania.Rok;
                        break;

                }
                element.Cykliczne = true;
                element.CzyCykliczne = "TAK";
                Service.GetInstance().ZmienDateDlaOdliczenia(element);
                Service.GetInstance().Oblicz(element);
            }
            else
            {
                element.Cykliczne = false;
                element.CzyCykliczne = "NIE";
                Service.GetInstance().Oblicz(element);
                if (element.DataOdliczania < DateTime.Now)
                {
                    element.Typ = TypOdliczania.Upłynął;
                }
                else
                {
                    element.Typ = TypOdliczania.Jednorazowe;
                }  
            }
            success = true;
            this.Close();
        }
        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void cykl_Checked(object sender, RoutedEventArgs e)
        {
             typCyklu.IsEnabled = true;
        }
        private void cykl_Unchecked(object sender, RoutedEventArgs e)
        {
             typCyklu.IsEnabled = false;
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

        private void buttonObrazek_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = NadajSciezke();
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "JPEG (.jpg) | *.jpg|PNG (.png) | *.png|Bitmap image (.bmp) | *.bmp|GIF (.gif) | *.gif";
            bool ? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                filename = filename.Substring(filename.LastIndexOf('\\') + 1);
                element.Obrazek = filename;
                element.Obraz = element.DodajObrazek(element.Obrazek);
                imageWydarzenia.DataContext = element;
            }
        }
        private void buttonUtworzObrazek_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Image";
            dialog.InitialDirectory = NadajSciezke();
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "JPEG (.jpg) | *.jpg|PNG (.png) | *.png|Bitmap image (.bmp) | *.bmp|GIF (.gif) | *.gif";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filename = dialog.FileName;
                string format = filename.Substring(filename.LastIndexOf('.') + 1);
                string targetfilename = NadajSciezke();
                targetfilename += element.ID.ToString() + "." + format;
                File.Copy(filename, targetfilename);
                targetfilename = element.ID.ToString() + "." + format;
                element.Obrazek = targetfilename;
                element.Obraz = element.DodajObrazek(element.Obrazek);
                imageWydarzenia.DataContext = element;
            }
        }
        private string NadajSciezke()
        {
            string sciezka = System.Reflection.Assembly.GetExecutingAssembly().Location;
            sciezka = sciezka.Substring(0, sciezka.LastIndexOf('\\') + 1);
            sciezka += "obrazki\\";
            return sciezka;
        }
    }
}
