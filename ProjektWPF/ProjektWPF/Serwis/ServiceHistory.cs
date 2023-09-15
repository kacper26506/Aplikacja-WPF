using ProjektWPF.Model_danych;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektWPF.Serwis
{
    public class ServiceHistory
    {
        private List<DaneHistoryczne> listHistory;
        private static ServiceHistory instance;
        private ServiceHistory()
        {
            Load();
        }
        public static ServiceHistory GetInstance()
        {
            if (instance == null)
            {
                instance = new ServiceHistory();
            }
            return instance;
        }
        public List<WydarzenieModel> Historia
        {
            get
            {
                List<WydarzenieModel> list = new List<WydarzenieModel>();
                for (int i = 0; i < listHistory.Count; i++)
                {
                    list.Add(ConvertToListItemHistory(listHistory[i]));
                }
                return list;
            }
        }
        public WydarzenieModel DodajdoHistorii(WydarzenieModel item)
        {
            DaneHistoryczne element = ConvertToHistory(item);
            listHistory.Add(element);
            Save();
            return item;
        }
        private void Load()
        {
            if (File.Exists("WydarzeniaHistoria.xml"))
            {
                listHistory = Deserialize<DaneHistoryczne>("WydarzeniaHistoria.xml");
            }
            else
            {
                listHistory = new List<DaneHistoryczne>();
            }
        }
        private void Save()
        {
            Serialize<DaneHistoryczne>(listHistory, "WydarzeniaHistoria.xml");
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
        DaneHistoryczne ConvertToHistory(WydarzenieModel item)
        {
            DaneHistoryczne element = new DaneHistoryczne();
            element.ID = item.ID;
            element.Nazwa = item.Nazwa;
            element.DataOdliczania = item.DataOdliczania;
            element.CzyCykliczne = item.CzyCykliczne;
            element.Typ = item.Typ;
            element.Obrazek = item.Obrazek;
            return element;
        }
        WydarzenieModel ConvertToListItemHistory(DaneHistoryczne item)
        {
            WydarzenieModel element = new WydarzenieModel();
            element.ID = item.ID;
            element.Nazwa = item.Nazwa;
            element.DataOdliczania = item.DataOdliczania;
            element.CzyCykliczne = item.CzyCykliczne;
            element.Typ = item.Typ;
            element.Obrazek = item.Obrazek;
            return element;
        }
    }
}
