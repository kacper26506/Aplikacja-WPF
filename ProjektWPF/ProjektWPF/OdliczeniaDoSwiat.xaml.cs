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
    public partial class OdliczeniaDoSwiat : Window
    {
        public OdliczeniaDoSwiat()
        {
            InitializeComponent();
        }

        private void buttonPotwierdz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonUsunSwieto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
