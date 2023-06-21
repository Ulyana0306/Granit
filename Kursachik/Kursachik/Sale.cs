using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Kursachik
{
    public partial class Sale : Form
    {
        ProductList productList;  //объявляем класс для его использования
        Basket basket; 
        double summaBasket = 0;
        public Sale()
        {
            productList = new ProductList();
            InitializeComponent();
            button1.Visible = false; //делаем невидимыми кнопки перед дальнейшим их испольованием
            label5.Visible = false;
            numericUpDown1.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //строка, чтоб в корзине выделялась вся строка
        }
        public Sale(ProductList productList)
        {
            this.productList = productList;
            basket = new Basket(this.productList);
            InitializeComponent();
            button1.Visible = false; //делаем невидимыми кнопки перед дальнейшим их испольованием
            label5.Visible = false;
            numericUpDown1.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //строка, чтоб в корзине выделялась вся строка
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            double check = 0;
            productList.Check(comboBox2.Text, comboBox3.Text, out s, out check); //отправлем данные в метод
            if (check == 0) //если запчасти нет, то выводим сообщение об этом
            {
                label4.ForeColor = Color.Red;
                label4.Text = "На складе не осталось запчасти";
                button1.Visible = false;
                label5.Visible = false;
                numericUpDown1.Visible = false;
            }
            else //выводим кнопку об добавлении в корзину
            {
                label4.ForeColor = Color.Black;
                label4.Text = s + string.Format("\nОсталось {0} шт. на складе", check);
                button1.Visible = true;
                label5.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown1.Maximum = Convert.ToInt32(check); //присваеваем максимум для выбора количества деталей
                numericUpDown1.Minimum = 1; //присваеваем минимум
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

        private void button1_Click(object sender, EventArgs e) //кнопка добавления товара в корзину
        {
            productList.Check(comboBox2.Text, comboBox3.Text, out string nothing, out double count);
            if (count != 0) //если запчастней не 0 на складе, то добавляем в корзину
            {
                basket.AddBasket(comboBox2.Text, comboBox3.Text, Convert.ToInt32(numericUpDown1.Value), out string s, out double sum); //добавляем товар в лист заказа
                summaBasket += sum * Convert.ToDouble(numericUpDown1.Value); //вычисляем общую сумму
                label6.Text = string.Format("Общая сумма: {0} руб.", summaBasket);
                dataGridView1.Rows.Add(comboBox3.Text, numericUpDown1.Value, sum * Convert.ToDouble(numericUpDown1.Value)); //добавляем в таблицу заказанные товары
            }
            else //если запчасть закончилась, выводим сообщение
            {
                label4.ForeColor = Color.Red;
                label4.Text = "На складе не осталось запчасти";
                button1.Visible = false;
                label5.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) //кнопка удаления товара из корзины
        {
            try
            {
                summaBasket -= Convert.ToDouble(dataGridView1.SelectedCells[2].Value); //отнимает удаляемую сумму
                basket.RemoveBasket(Convert.ToString(dataGridView1.SelectedCells[0].Value)); //удаляем товар из листа
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex); //удаляем товар из таблицы
                label6.Text = string.Format("Общая сумма: {0} руб.", summaBasket); //выводим обновленную сумму
            }
            catch (Exception) //если товара нет, то и удалять нечего
            {
                MessageBox.Show("Корзина пуста!");
            }
        }

        private void button4_Click(object sender, EventArgs e) //кнопка оформления заказа и вывода чека
        {
            string s = "";
            double check = 0;
            switch (basket.CheckBasket()) //проверяем пустая ли корзина
            {
                case true:
                    MessageBox.Show("Корзина пуста!");
                    break;
                case false: //если корзина не пустая, то выводим чек
                    string message = string.Format("------{0}------\n", DateTime.Now);
                    message += basket.Tab();
                    message += string.Format("К оплате: {0}\nВсего хорошего!", summaBasket);
                    string title = "Оформление заказа";
                    productList.RefreshItems(basket.GetProducts,ref productList.details);
                    basket.ClearBusket(); //очищаем корзину
                    dataGridView1.Rows.Clear(); //очищаем корзину
                    dataGridView1.Refresh(); //очищаем корзину
                    summaBasket = 0;
                    label6.Text = string.Empty; //очищаем корзину
                    productList.Check(comboBox2.Text, comboBox3.Text, out s, out check); //отправлем данные в метод
                    label4.Text = s + string.Format("\nОсталось {0} шт. на складе", check);
                    DialogResult result = MessageBox.Show(message + string.Format("\n\nРаспечатать чек?"), title, MessageBoxButtons.YesNo); //выводим чек
                    if (result == DialogResult.Yes)
                    {
                        FileDialog save = new SaveFileDialog(); //команды для сохранения чека в файл
                        save.InitialDirectory = "D:";
                        save.Filter = "txt files (*.txt)|*.txt";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(save.FileName, true);
                            writer.WriteLine(message);
                            writer.Close();
                        }
                    }
                    break;
            }
        }

        private void Sale_FormClosing(object sender, FormClosingEventArgs e) //выход приложения при закрытии формы
        {
            Environment.Exit(0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
