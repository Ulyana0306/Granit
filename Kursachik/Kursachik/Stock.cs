﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kursachik
{
    public abstract class Stock//Склад
    {
        public  List<Product> details = new List<Product>() //список деталей
        {
            new Product("Двигатель","Воздушный фильтр",45,5),
            new Product("Двигатель","Блок цилиндров",202,8),
            new Product("Двигатель","Водяной насос",43,3),
            new Product("Двигатель","Выхлопная труба",54,4),
            new Product("Двигатель","ГБЦ",78,6),
            new Product("Двигатель","Генератор",46,5),
            new Product("Двигатель","Глушитель",32,9),
            new Product("Двигатель","Диск сцепления",30,7),
            new Product("Двигатель","Коленвал",87,4),
            new Product("Двигатель","Коллектор",67,5),
            new Product("Двигатель","Коробка передач",102,2),
            new Product("Двигатель","Клапана",87,22),
            new Product("Двигатель","Крышка ГБЦ",54,7),
            new Product("Двигатель","Крышка ГРМ",43,6),
            new Product("Двигатель","Магистраль сцеплениия",24,4),
            new Product("Двигатель","Масляный поддон",56,9),
            new Product("Двигатель","Масляный фильтр",35,5),
            new Product("Двигатель","Маховик",67,7),
            new Product("Двигатель","Механизм сцепления",45,1),
            new Product("Двигатель","Поршень",87,5),
            new Product("Двигатель","Привод",98,7),
            new Product("Двигатель","Прокладка ГБЦ",47,5),
            new Product("Двигатель","Радиатор",76,7),
            new Product("Двигатель","Распредвал",65,4),
            new Product("Двигатель","Катушка зажигания",32,5),
            new Product("Двигатель","Патруб топливного бака",23,12),
            new Product("Двигатель","Стартер",37,6),
            new Product("Двигатель","Топливный насос",45,8),
            new Product("Двигатель","Топливный фильтр",34,16),
            new Product("Двигатель","Цепь ГРМ",60,8),
            new Product("Двигатель","Цилиндр сцепления",67,9),
            new Product("Двигатель","Шкив коленвала",56,5),
            new Product("Двигатель","Шланг радиатора",23,7),
            new Product("Подвеска","Амортизатор",56,11),
            new Product("Подвеска","Барабанный тормоз",37,14),
            new Product("Подвеска","Дисковый тормоз",50,16),
            new Product("Подвеска","Подрамник",67,5),
            new Product("Подвеска","Полуось",48,17),
            new Product("Подвеска","Поперечный рычаг",44,4),
            new Product("Подвеска","Продольный рычаг",45,9),
            new Product("Подвеска","Пружина",15,22),
            new Product("Подвеска","Рулевая колонка",78,6),
            new Product("Подвеска","Рулевая рейка",45,7),
            new Product("Подвеска","Рулевая тяга",65,18),
            new Product("Подвеска","Наконечник рулевой тяги",23,32),
            new Product("Подвеска","Ручник",37,5),
            new Product("Подвеска","Тормозной цилиндр",47,9),
            new Product("Подвеска","Тормозная магистраль",46,12),
            new Product("Подвеска","Стойка",42,12),
            new Product("Подвеска","Шпиндель",12,26),
            new Product("Кузов","Передний бампер",32,8),
            new Product("Кузов","Задний бампер",30,8),
            new Product("Кузов","Брызговик",10,46),
            new Product("Кузов","Дверь",43,12),
            new Product("Кузов","Задние сидения",50,3),
            new Product("Кузов","Задние огни",27,8),
            new Product("Кузов","Передние фары",28,10),
            new Product("Кузов","Задняя панель",32,10),
            new Product("Кузов","Капот",62,9),
            new Product("Кузов","Крыло",23,3),
            new Product("Кузов","Панель приборов",15,4),
            new Product("Кузов","Приборная доска",20,6),
            new Product("Кузов","Решетка радиатора",21,8),
            new Product("Кузов","Рулевое колесо",32,5),
            new Product("Кузов","Сидение",42,21),
            new Product("КУзов","Топливный бак",51,7),
            new Product("Электрика","ЭБУ",68,0),
            new Product("Электрика","Провода крепления",5,56),
            new Product("Электрика","Аккумулятор",35,10)
        };
    }
}
