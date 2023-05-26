using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDB
{
    public class DBPen
    {
        /// Коллекция данных связанная с интерфейсом
        public ObservableCollection<Pen> pens;

        public DBPen()
        {
            pens = new ObservableCollection<Pen>();
        }

        /// Добавление ручки в список
        public void AddBook(string brend, string color, double thickness, string automatic, int price)
        {
            Pen newPen = new Pen(brend, color, thickness, automatic, price);
            pens.Add(newPen);
        }


        /// Сохранить БД в файл
        public void SaveDB(string name)
        {
            if (!System.IO.File.Exists(name))
                throw new Exception("Файл не существует");
            ///Почитать
            using (StreamWriter sw = new StreamWriter(name, false, System.Text.Encoding.Unicode))
            {
                foreach (Pen s in pens)
                {
                    sw.WriteLine(s.ToString());
                }
            }
        }

        /// Открыть БД из файла
        public void OpenFile(string name)
        {
            if (!System.IO.File.Exists(name))
                throw new Exception("Файл не существует");

            if (pens.Count != 0)
                DeleteDB();

            using (StreamReader sw = new StreamReader(name))
            {
                while (!sw.EndOfStream)
                {
                    string str = sw.ReadLine();
                    String[] dataFromFile = str.Split(new String[] { "|" },
                        StringSplitOptions.RemoveEmptyEntries);

                    string brend = dataFromFile[0];
                    string color = dataFromFile[1];
                    double thickness = double.Parse(dataFromFile[2]);
                    string automatic = dataFromFile[3];
                    int price = int.Parse(dataFromFile[4]);
                    AddBook(brend, color, thickness, automatic, price);
                }
            }
        }

        /// Удаление всей бд
        public void DeleteDB()
        {
            pens.Clear();
        }
    }
}

