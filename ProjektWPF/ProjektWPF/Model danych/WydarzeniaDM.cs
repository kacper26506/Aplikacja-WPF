using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjektWPF.Model_danych
{
    public class WydarzeniaDM
    {
        public Guid ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataOdliczania { get; set; }
        public bool Cykliczne { get; set; }
        public string CzyCykliczne { get; set; }
        public TypOdliczania Typ { get; set; }
        public int IleDni { get; set; }
        public string Obrazek { get; set; }
        public string DataUtworzenia { get; set; }
        public string Data
        {
            get
            {
                return DataOdliczania.ToString();
            }
        }
    }
}
