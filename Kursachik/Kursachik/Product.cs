using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursachik
{
    public class Product
    {
        private int _volume;
        private string _category;
        private double _price;

        public Product(string category, string name, double price, int volume)
        {
            Category = category;
            Name = name;
            Price = price;
            Volume = volume;
        }
        //название категории
        public string Category
        {
            get { return _category; }
            private set { _category = value; }
        }
        private string _name;
        //название детали
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        //цена детали
        public double Price
        {
            get { return _price; }
            private set { _price = value; }
        }
        //количество на складе
        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
        public override string ToString()
        {
            return "Название товара " + Name;
        }
    }
}
