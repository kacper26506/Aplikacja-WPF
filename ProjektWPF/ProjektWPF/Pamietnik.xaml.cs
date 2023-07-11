﻿using System;
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
    /// Logika interakcji dla klasy Pamietnik.xaml
    /// </summary>
    public partial class Pamietnik : Window
    {
        public Pamietnik()
        {
            InitializeComponent();
        }

        private void buttonOpusc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
