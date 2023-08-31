﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.Model_danych
{
    public class DaneHistoryczne
    {
        public Guid ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataOdliczania { get; set; }
        public string CzyCykliczne { get; set; }
        public TypOdliczania Typ { get; set; }
        public string Data
        {
            get
            {
                return DataOdliczania.ToString();
            }
        }
    }
}