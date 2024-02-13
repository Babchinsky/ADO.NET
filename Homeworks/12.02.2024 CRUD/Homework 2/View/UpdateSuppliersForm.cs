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
    public partial class UpdateSuppliersForm : Form
    {
        Database database;
        public UpdateSuppliersForm(Database database)
        {
            InitializeComponent();
            this.database = database;
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            comboBox1.DataSource = database.GetDistinctSuppliers();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму
            this.Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, есть ли уже в БД
                List<string> distinctSuppliers = database.GetDistinctSuppliers();
                foreach (string supplier in distinctSuppliers)
                {
                    if (textBox1.Text == supplier)
                    {
                        MessageBox.Show("Такой поставщик уже есть. Попробуйте ввести другой");
                        return;
                    }
                }

                database.SendRequest($"UPDATE Suppliers SET Name = '{textBox1.Text.ToString()}' WHERE Name = '{comboBox1.SelectedItem.ToString()}';");
                MessageBox.Show($"Поставщик '{comboBox1.SelectedItem}' успешно изменён на '{textBox1.Text}' в БД");
                UpdateComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Проверка textBox
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                buttonChange.Enabled = false;
            }
            else buttonChange.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem?.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            database.DeleteSupplierWithConnectedProducts(comboBox1.Text);
            MessageBox.Show($"Поставщик '{comboBox1.Text}' успешно удалён из БД вместе с зависящими продуктами");
            UpdateComboBox();
        }
    }
}
