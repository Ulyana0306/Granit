using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kursachik
{
    public partial class Load : Form
    {
        ProductList productList; //объявляем класс для дальнейшего использования методов из него
        public Load()
        {
            productList = new ProductList();
            InitializeComponent();
        }
        public Load(ProductList productList)
        {
            InitializeComponent();
            this.productList = productList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productList.AddList(comboBox2.Text, comboBox3.Text, Convert.ToInt32(textBox1.Text))==true) //проверяем, если добавился товар, то выводм сообщение
            {
                label5.Text = "Добавлено!";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //делаем так, чтобы было невозможно выбрать делать без выбора категории
        {
            switch (comboBox2.Text)
            {
                case "Двигатель":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "Воздушный фильтр", "Блок цилиндров", "Водяной насос", "Выхлопная труба", "ГБЦ", "Генератор", "Глушитель", "Диск сцепления", "Коленвал", "Коллектор", "Коробка передач", "Клапана", "Крышка ГБЦ", "Крышка ГРМ", "Магистраль сцепления", "Масляный поддон", "Масляный фильтр", "Маховик", "Механизм сцепления", "Поршень", "Привод", "Прокладка ГБЦ", "Радиатор", "Распредвал", "Катушка зажигания", "Патруб топливного бака", "Стартер", "Топливный насос", "Топливный фильтр", "Цепь ГРМ", "Цилиндр сцепления", "Шкив коленвала", "Шланг радиатора" });
                    break;
                case "Подвеска":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "Амортизатор", "Барабанный тормоз", "Дисковый тормоз", "Подрамник", "Полуось", "Поперечный рычаг", "Продольный рычаг", "Пружина", "Рулевая колонка", "Рулевая рейка", "Рулевая тяга", "Наконечник рулевой тяги", "Ручник", "Тормозной цилиндр", "Тормозная магистраль", "Стойка", "Шпиндель" });
                    break;
                case "Кузов":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "Передний бампер", "Задний бампер", "Брызговик", "Дверь", "Задние сидения", "Задние огни", "Передние фары", "Задняя панель", "Капот", "Крышка багажника", "Крыло", "Панель приборов", "Приборная доска", "Решетка радиатора", "Рулевое колесо", "Сидение", "Топливный бак" });
                    break;
                case "Электрика":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "ЭБУ", "Провода крепления", "Аккумулятор" });
                    break;
            }
        }

        private void Load_FormClosed(object sender, FormClosedEventArgs e) //выводим первоначальную форму, если закроем эту форму
        {
            Form f = Application.OpenForms[0];
            f.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Quite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1(productList);
            first.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            first.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            first.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            first.Show(); // отображаем Form1 
            this.Hide();
        }
    }
}
