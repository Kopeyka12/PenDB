using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDB
{
    public class Pen
    {
        string brend;
        string color;
        int price;
        double thickness;
        string automatic;


        public Pen(string brend, string color, double thickness, string automatic, int price)
        {
            this.brend = brend;
            this.color = color;
            this.thickness = thickness;
            this.automatic = automatic;
            this.price = price;
        }

        public string Марка
        {
            get { return brend; }
            set { brend = value; }
        }

        public string Цвет
        {
            get { return color; }
            set { color = value; }
        }

        public double Толщина_пасты
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public string Автоматическая
        {
            get { return automatic; }
            set { automatic = value; }
        }

        public int Цена
        {
            get { return price; }
            set { price = value; }
        }

        public override string ToString()
        {
            return brend + "|" + color + "|" + thickness + "|" +
                automatic + "|" + price;
        }
    }
}
