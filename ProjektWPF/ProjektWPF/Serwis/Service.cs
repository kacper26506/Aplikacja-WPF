using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Serialization;
using ProjektWPF.Model_danych;

namespace ProjektWPF.Serwis
{
    public class Service
    {
        private List<WydarzeniaDM> listDM;
        private static Service instance;
        private Service()
        {
            Load();
        }
        public static Service GetInstance()
        {
            if (instance == null)
            {
                instance = new Service();
            }
            return instance;
        }
        public List<WydarzenieModel> Wydarzenia
        {
            get
            {
                List<WydarzenieModel> list = new List<WydarzenieModel>();
                for (int i = 0; i < listDM.Count; i++)
                {
                    list.Add(ConvertToListItemVM(listDM[i]));
                }
                return list;
            }
        }
        public void AktualizujWydarzenia(List<WydarzenieModel> listaWydarzen)
        {
            for (int i = 0; i < listaWydarzen.Count; i++)
            {
                WydarzenieModel element = listaWydarzen[i];
                if (element.DataOdliczania < DateTime.Now)
                {
                    if (element.Cykliczne)
                    {
                        ZmienDateDlaOdliczeniaIWpiszDoHistorii(element);
                        Oblicz(element);
                        EdytujWydarzenie(element);
                    }
                    else
                    {
                        element.Typ = TypOdliczania.Upłynął;
                        Oblicz(element);
                        EdytujWydarzenie(element);
                        ServiceHistory.GetInstance().DodajdoHistorii(element);
                        UsunWydarzenie(element.ID);
                        listaWydarzen.Remove(element);
                        i--;
                    }
                }
                //Oblicz(element);
                element.PelnaNazwa = element.Nazwa + " " + PozostalyCzas(element.DataOdliczania);
            }
        }
        private string PozostalyCzas(DateTime czas)
        {
            long dni, godziny, minuty, sekundy;
            DateTime czasAktualny = DateTime.Now;
            sekundy = (long)(czas- DateTime.Now).TotalSeconds;
            
            minuty = sekundy / 60;
            godziny = minuty / 60;
            dni = godziny / 24;
            sekundy %= 60;
            minuty %= 60;
            godziny %= 24;
            string pelnaNazwa = "Do wydarzenia zostało ";
            switch (dni)
            {
                case 1:
                    pelnaNazwa += "1 dzień ";
                    break;
                default:
                    pelnaNazwa += dni;
                    pelnaNazwa += " dni ";
                    break;
            }
            pelnaNazwa += godziny;
            pelnaNazwa += " godz ";
            pelnaNazwa += minuty;
            pelnaNazwa += " min ";
            pelnaNazwa += sekundy;
            pelnaNazwa += " sek";
            return pelnaNazwa;
        }
        public WydarzenieModel DodajWydarzenie(WydarzenieModel item)
        {
            WydarzeniaDM element = Convert(item);
            listDM.Add(element);
            Save();
            return item;
        }
        public void EdytujWydarzenie(WydarzenieModel item)
        {
            for (int i = 0; i < listDM.Count; i++)
            {
                if (listDM[i].ID == item.ID)
                {
                    listDM[i].Cykliczne = item.Cykliczne;
                    listDM[i].CzyCykliczne = item.CzyCykliczne;
                    listDM[i].Nazwa = item.Nazwa;
                    listDM[i].ID = item.ID;
                    listDM[i].DataOdliczania = item.DataOdliczania;
                    listDM[i].Typ = item.Typ;
                    listDM[i].IleDni = item.IleDni;
                    listDM[i].Obrazek = item.Obrazek;
                    listDM[i].DataUtworzenia = item.DataUtworzenia;
                    Save();
                    return;
                }
            }
        }
        public void UsunWydarzenie(Guid index)
        {
            for (int i = 0; i < listDM.Count; i++)
            {
                if (listDM[i].ID == index)
                {
                    listDM.RemoveAt(i);
                    Save();
                    return;
                }
            }
        }
        public void Oblicz(WydarzenieModel item)
        {
            DateTime DataPoczatkowa = DateTime.Now;
            item.IleDni = 0;
            while (DataPoczatkowa < item.DataOdliczania)
            {
                DataPoczatkowa = DataPoczatkowa.AddDays(1);
                item.IleDni++;
            }
        }
        public void ZmienDateDlaOdliczenia(WydarzenieModel item)
        {
            while (item.DataOdliczania < DateTime.Now)
            {
                switch (item.Typ)
                {
                    case TypOdliczania.Rok:
                        item.DataOdliczania = item.DataOdliczania.AddYears(1);
                        break;
                    case TypOdliczania.Kwartał:
                        item.DataOdliczania = item.DataOdliczania.AddMonths(3);
                        break;
                    case TypOdliczania.Miesiąc:
                        item.DataOdliczania = item.DataOdliczania.AddMonths(1);
                        break;
                    case TypOdliczania.Tydzień:
                        item.DataOdliczania = item.DataOdliczania.AddDays(7);
                        break;
                    case TypOdliczania.Dzień:
                        item.DataOdliczania = item.DataOdliczania.AddDays(1);
                        break;
                }
            }
        }
        public void ZmienDateDlaOdliczeniaIWpiszDoHistorii(WydarzenieModel item)
        {
            while (item.DataOdliczania < DateTime.Now)
            {
                switch (item.Typ)
                {
                    case TypOdliczania.Rok:
                        ServiceHistory.GetInstance().DodajdoHistorii(item);
                        item.DataOdliczania = item.DataOdliczania.AddYears(1);
                        break;
                    case TypOdliczania.Kwartał:
                        ServiceHistory.GetInstance().DodajdoHistorii(item);
                        item.DataOdliczania = item.DataOdliczania.AddMonths(3);
                        break;
                    case TypOdliczania.Miesiąc:
                        ServiceHistory.GetInstance().DodajdoHistorii(item);
                        item.DataOdliczania = item.DataOdliczania.AddMonths(1);
                        break;
                    case TypOdliczania.Tydzień:
                        ServiceHistory.GetInstance().DodajdoHistorii(item);
                        item.DataOdliczania = item.DataOdliczania.AddDays(7);
                        break;
                    case TypOdliczania.Dzień:
                        ServiceHistory.GetInstance().DodajdoHistorii(item);
                        item.DataOdliczania = item.DataOdliczania.AddDays(1);
                        break;
                }
            }
        }
        private void Load()
        {
            if (File.Exists("WydarzeniaData.xml"))
            {
                listDM = Deserialize<WydarzeniaDM>("WydarzeniaData.xml");
            }
            else
            {
                listDM = new List<WydarzeniaDM>();
            }
        }
        
        private void Save()
        {
            Serialize<WydarzeniaDM>(listDM, "WydarzeniaData.xml") ;
        }
        
        static List<T> Deserialize<T>(string fileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
            TextReader reader = new StreamReader(fileName);
            object obj = deserializer.Deserialize(reader);
            reader.Close();
            return (List<T>)obj;
        }
        static void Serialize<T>(List<T> list, string fileName)
        {
            if (File.Exists(fileName))
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            Type someType = list.GetType();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }
        WydarzeniaDM Convert(WydarzenieModel item)
        {
            WydarzeniaDM element = new WydarzeniaDM();
            element.ID = item.ID;
            element.Nazwa = item.Nazwa;
            element.DataOdliczania = item.DataOdliczania;
            element.Cykliczne = item.Cykliczne;
            element.CzyCykliczne = item.CzyCykliczne;
            element.Typ = item.Typ;
            element.IleDni = item.IleDni;
            element.Obrazek = item.Obrazek;
            element.DataUtworzenia = item.DataUtworzenia;
            return element;
        }
        WydarzenieModel ConvertToListItemVM(WydarzeniaDM item)
        {
            WydarzenieModel element = new WydarzenieModel();
            element.ID = item.ID;
            element.Nazwa = item.Nazwa;
            element.DataOdliczania = item.DataOdliczania;
            element.Cykliczne = item.Cykliczne;
            element.CzyCykliczne = item.CzyCykliczne;
            element.Typ = item.Typ;
            element.IleDni = item.IleDni;
            element.Obrazek = item.Obrazek;
            element.Obraz = element.DodajObrazek(element.Obrazek);
            element.DataUtworzenia = item.DataUtworzenia;
            return element;
        }
    }
}
