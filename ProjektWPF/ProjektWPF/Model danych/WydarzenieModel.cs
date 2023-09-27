using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using ProjektWPF.Czas;
using System.Runtime.CompilerServices;

namespace ProjektWPF.Model_danych
{
    public class WydarzenieModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Guid ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataOdliczania { get; set; }
        public bool Cykliczne { get; set; }
        public string CzyCykliczne { get; set; }
        public TypOdliczania Typ { get; set; }
        public int IleDni { get; set; }
        public string Obrazek { get; set; }
        public BitmapImage Obraz { get; set; }
        private string pelnaNazwa;
        public string PelnaNazwa
        {
            get
            {
                return pelnaNazwa;
            }
            set
            {
                pelnaNazwa = value;
                OnPropertyChanged();
            }
        }


        public string DataUtworzenia { get; set; }
        private Data data { get; set; }
        public WydarzenieModel()
        {
            this.ID = Guid.NewGuid();
            this.Nazwa = "Nowe wydarzenie";
            this.DataOdliczania = DateTime.Now;
            this.Cykliczne = false;
            this.CzyCykliczne = "NIE";
            this.Typ = TypOdliczania.Jednorazowe;
            this.IleDni = 0;
            this.Obrazek = "image.png";
            this.Obraz = DodajObrazek(Obrazek);
            data = new Data();
            this.DataUtworzenia = data.DataPowstania(DateTime.Now);
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
            this.DataUtworzenia = model.DataUtworzenia;
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
