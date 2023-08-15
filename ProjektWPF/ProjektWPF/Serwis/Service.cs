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
        public Service()
        {
            Load();
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
        public WydarzenieModel DodajWydarzenie(WydarzenieModel item)
        {
            WydarzeniaDM element = Convert(item);
            listDM.Add(element);
            Save();
            return item;
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
            return element;
        }

    }
}
