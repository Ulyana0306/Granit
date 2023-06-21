using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Kursachik
{
    public partial class Form1 : Form
    {
        ProductList ProductList;
        public Form1()
        {
            ProductList = new ProductList();
            InitializeComponent();
        }
        public Form1(ProductList productList)
        {
            ProductList = productList;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //вызов формы продажи
        {
            Sale s = new Sale(ProductList);
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //вызов формы добавления на склад
        {
            try //так как после закрытия формы добавления мы захотим еще раз открыть ее, делаем исключение
            {
                Load l = new Load(ProductList);
                l.Show();
                this.Hide();
            }
            catch (Exception)
            {
                Load l = new Load(ProductList);
                l.Show();
            }
        }

        private void Quite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ///
     


    }
}
