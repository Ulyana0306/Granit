using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kursachik
{
    public class ProductList : Stock
    {
        public ProductList() { }//конструктор класса

        public bool AddList(string Category, string Name, int Volume) //метод добавления детали в лист
        {
            bool suc = false;
            for (int i = 0; i < details.Count; i++)
            {
                if (Category == details[i].Category && Name == details[i].Name)
                {
                    details[i].Volume += Volume;
                    suc = true; //если деталь найдена и добавлена, то возвращаем true
                }
            }
            return suc;
        }

        public void Check(string Category, string Name, out string s, out double d) //проверяем наличие и количество деталей на складе
        {
            s = "";
            d = 0;
            for (int i = 0; i < details.Count; i++)
            {
                if (Category == details[i].Category && Name == details[i].Name)
                {
                    s = string.Format("Выбранная деталь стоит {0}", details[i].Price);
                    d = details[i].Volume; //возвращаем количество деталей
                }
            }
            if (s == "")
            {
                s = "Выбранной детали не существует";
            }
        }
        public void RefreshItems(List<Product> basket, ref List<Product> products)
        {
            var temp = products;
            int j = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Name == basket[j].Name)
                {
                    temp[i].Volume = temp[i].Volume - basket[j].Volume;
                    if (basket.Count-1 != j)
                    {
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            products = temp;
        }
    }
}
