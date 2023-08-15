using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Documents;

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
        public WydarzenieModel()
        {
            this.ID = Guid.NewGuid();
            this.Nazwa = "";
            this.DataOdliczania = DateTime.Now;
            this.Cykliczne = false;
            this.CzyCykliczne = "NIE";
        }
        public WydarzenieModel(WydarzenieModel model)
        {
            this.ID = model.ID;
            this.Nazwa = model.Nazwa;
            this.DataOdliczania = model.DataOdliczania;
            this.Cykliczne = model.Cykliczne;
            this.CzyCykliczne = model.CzyCykliczne;
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
