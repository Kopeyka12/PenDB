// @author Мирошин В. И.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDB
{    
    //Класс Pen
    public class Pen
    {   //ПОЛЯ
        string brend;       //бренд
        string color;       //цвет
        int price;          //цена
        double thickness;   //толщина линии
        string automatic;   //автоматическая 

        //Конструктор с параметрами
        public Pen(string brend, string color, double thickness, string automatic, int price)
        {
            this.brend = brend;
            this.color = color;
            this.thickness = thickness;
            this.automatic = automatic;
            this.price = price;
        }
        //В методе задаем и выдаем значение Бренд 
        public string Brend
        {
            get { return brend; }
            set { brend = value; }
        }
        //В методе задаем и выдаем значение Цвет
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        //В методе задаем и выдаем значение Толщина письма
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        //В методе задаем и выдаем значение Автоматический
        public string Automatic
        {
            get { return automatic; }
            set { automatic = value; }
        }
        //В методе задаем и выдаем значение Цена
        public int Price
        {
            get { return price; }
            set {  price = value; }
        }
        //В переопределнном методе выводем значание с разделительным знаком
        public override string ToString()
        {
            return brend + "|" + color + "|" + thickness + "|" +
                automatic + "|" + price;
        }
    }
}
