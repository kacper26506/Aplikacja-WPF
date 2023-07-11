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
    /// Logika interakcji dla klasy DodawanieEdycjaWydarzen.xaml
    /// </summary>
    public partial class DodawanieEdycjaWydarzen : Window
    {
        public DodawanieEdycjaWydarzen()
        {
            InitializeComponent();
        }

        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonPotwierdz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
