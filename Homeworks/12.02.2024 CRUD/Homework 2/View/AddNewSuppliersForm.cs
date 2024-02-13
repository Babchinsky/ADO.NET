using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework_2.Model;

namespace Homework_3
{
    public partial class AddNewSuppliersForm : Form
    {
        Database database;
        public AddNewSuppliersForm(Database database)
        {
            InitializeComponent();
            this.database = database;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, есть ли уже в БД
                List<string> distictSuppliers = database.GetDistinctSuppliers();
                foreach (string supplier in distictSuppliers)
                {
                    if (textBox1.Text == supplier)
                    {
                        MessageBox.Show("Такой поставщик товаров уже есть. Попробуйте ввести другой");
                        return;
                    }
                }
                database.SendRequest($"INSERT INTO Suppliers (Name) VALUES ('{textBox1.Text}');");
                MessageBox.Show($"Поставщик товара '{textBox1.Text}' успешно добавлен в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Проверка textBox
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                buttonAdd.Enabled = false;
            }
            else buttonAdd.Enabled = true;
        }
    }
}
