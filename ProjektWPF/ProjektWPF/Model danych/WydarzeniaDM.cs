using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.Model_danych
{
    public class WydarzeniaDM
    {
        public Guid ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataOdliczania { get; set; }
        public bool Cykliczne { get; set; }
        public string CzyCykliczne { get; set; }
        public WydarzeniaDM Convert(WydarzenieModel item)
        {
            WydarzeniaDM element = new WydarzeniaDM();
            element.ID = item.ID;
            element.Nazwa = item.Nazwa;
            element.DataOdliczania = item.DataOdliczania;
            element.Cykliczne = item.Cykliczne;
            element.CzyCykliczne = item.CzyCykliczne;
            return element;
        }
        public string Data
        {
            get
            {
                return DataOdliczania.ToString();
            }
        }
    }
}
