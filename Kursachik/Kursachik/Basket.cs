using System;
using System.Collections.Generic;

namespace Kursachik
{
    internal class Basket
    {
        List<Product> basket;
        List<Product> Products;

        public List<Product> GetProducts { get { return basket; } }

        public Basket(ProductList productList)
        {
            //список деталей в корзине
            basket = new List<Product>();

            //получаем весь список деталей на складе
            Products = productList.details;
        }

        //добавляем товар в корзину
        public void AddBasket(string Category, string Name, int Volume, out string s, out double OutPrice) 
        {
            
            OutPrice = 0;
            s = "";
            for (int i = 0; i < Products.Count; i++)
            {
                if (Category == Products[i].Category && Name == Products[i].Name)
                {
                    //Products[i].Volume -= Volume; //отнимаем заказаное количество от количества на складе
                    OutPrice = Products[i].Price;
                    basket.Add(new Product(Category, Name, OutPrice, Volume)); //добавляем товар в корзину
                }
            }
        }

        //проверяем пуста ли корзина
        public bool CheckBasket() 
        {
            bool empty = false;
            if (basket.Count == 0)
                empty = true;
            return empty;
        }

        public void RemoveBasket(string Name) //удаляем товар из листа корзины
        {
            for (int i = 0; i < basket.Count; i++)
            {
                if (Name == basket[i].Name)
                {
                    basket.RemoveAt(i);
                }
            }
        }
        public string Tab() //вывод чека из листа корзины
        {
            string s = "";
            for (int i = 0; i < basket.Count; i++)
            {
                s += string.Format("{0} x{1} --- {2} руб.\n", basket[i].Name, basket[i].Volume, basket[i].Price * Convert.ToDouble(basket[i].Volume));
            }
            return s;
        }

        public void ClearBusket() //очищаем лист корзины
        {
            basket.Clear();
        }
    }
}