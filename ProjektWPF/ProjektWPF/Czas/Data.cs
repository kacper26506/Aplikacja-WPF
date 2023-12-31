﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ProjektWPF.Czas
{
    public class Data
    {
        public static readonly string[] DzienTygodnia = { "niedziela", "poniedziałek", "wtorek", "środa", "czwartek", "piątek", "sobota"};
        public int Dzien { get; set; }
        public static readonly string[] NazwaMiesiaca = {"stycznia", "lutego", "marca", "kwietnia", "maja", "czerwca", 
        "lipca", "sierpnia", "września", "października", "listopada", "grudnia"};
        public int Rok { get; set; }
        public object Godzina { get; set; }
        public object Minuta { get; set; }
        public object Sekunda { get; set; }
        public object UstawNumer(int warunek)
        {
            object item;
            if (warunek < 10)
            {
                item = "0" + warunek;
            }
            else
            {
                item = warunek;
            }
            return item;
        }
        public string DataPowstania(DateTime czas)
        {
            return DzienTygodnia[(int)czas.DayOfWeek] + ", " + czas.Day + " " + NazwaMiesiaca[czas.Month - 1] + " " + 
            czas.Year + " " + UstawNumer(czas.Hour) + ":" + UstawNumer(czas.Minute) + ":" + UstawNumer(czas.Second);
        }
    }
}
