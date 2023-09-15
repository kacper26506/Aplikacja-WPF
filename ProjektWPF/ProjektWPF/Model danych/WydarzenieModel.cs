using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace ProjektWPF.Model_danych
{
    public class WydarzenieModel
    {
        public Guid ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataOdliczania { get; set; }
        public bool Cykliczne { get; set; }
        public string CzyCykliczne { get; set; }
        public TypOdliczania Typ { get; set; }
        public int IleDni { get; set; }
        public string Obrazek { get; set; }
        public BitmapImage Obraz { get; set; }
        public string PelnaNazwa { get; set; }
        public WydarzenieModel()
        {
            this.ID = Guid.NewGuid();
            this.Nazwa = "TVN Szurbo";
            this.DataOdliczania = DateTime.Now;
            this.Cykliczne = false;
            this.CzyCykliczne = "NIE";
            this.Typ = TypOdliczania.Jednorazowe;
            this.IleDni = 0;
            this.Obrazek = "R.bmp";
            this.Obraz = DodajObrazek(Obrazek);
        }
        public WydarzenieModel(WydarzenieModel model)
        {
            this.ID = model.ID;
            this.Nazwa = model.Nazwa;
            this.DataOdliczania = model.DataOdliczania;
            this.Cykliczne = model.Cykliczne;
            this.CzyCykliczne = model.CzyCykliczne;
            this.Typ = model.Typ;
            this.IleDni = model.IleDni;
            this.Obrazek = model.Obrazek;
            this.Obraz = DodajObrazek(Obrazek);
        }
        public BitmapImage DodajObrazek(string nazwaPliku)
        {
            string sciezka = System.Reflection.Assembly.GetExecutingAssembly().Location;
            sciezka = sciezka.Substring(0, sciezka.LastIndexOf('\\') + 1);
            sciezka += "obrazki\\" + nazwaPliku;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sciezka);
            bitmap.EndInit();
            return bitmap;
        }
        public string Data
        {
            get
            {
                return DataOdliczania.ToString();
            }
        }
        public int Hour
        {
            get
            {
                return DataOdliczania.Hour;
            }
            set
            {
                DataOdliczania = DataOdliczania.AddHours(DataOdliczania.Hour * (-1));
                DataOdliczania = DataOdliczania.AddHours(value);
            }
        }
        public int Minute
        {
            get
            {
                return DataOdliczania.Minute;
            }
            set
            {
                DataOdliczania = DataOdliczania.AddMinutes(DataOdliczania.Minute * (-1));
                DataOdliczania = DataOdliczania.AddMinutes(value);
            }
        }
    }
}
