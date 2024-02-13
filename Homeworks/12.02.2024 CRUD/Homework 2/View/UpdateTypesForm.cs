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
    public partial class UpdateTypesForm : Form
    {
        Database database;
        public UpdateTypesForm(Database database)
        {
            InitializeComponent();
            this.database = database;
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            comboBox1.DataSource = database.GetDistinctTypes();
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
                List<string> distictTypes = database.GetDistinctTypes();
                foreach (string type in distictTypes)
                {
                    if (textBox1.Text == type)
                    {
                        MessageBox.Show("Такой тип товаров уже есть. Попробуйте ввести другой");
                        return;
                    }
                }

                database.SendRequest($"UPDATE ProductTypes SET Name = '{textBox1.Text}' WHERE Name = '{comboBox1.SelectedItem}';");
                MessageBox.Show($"Тип товара '{comboBox1.SelectedItem}' успешно изменён на '{textBox1.Text}' в БД");
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
            database.DeleteTypeWithConnectedProducts(comboBox1.Text);
            MessageBox.Show($"Тип товара '{comboBox1.Text}' успешно удалён из БД вместе с зависящими продуктами");
            UpdateComboBox();
        }
    }
}
