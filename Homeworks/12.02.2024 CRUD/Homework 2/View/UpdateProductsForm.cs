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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework_3
{
    public partial class UpdateProductsForm : Form
    {
        Database database;
        List<Product> products;
        List<string> distinctSuppliers;
        List<string> distinctTypes;
        public UpdateProductsForm(Database database)
        {
            InitializeComponent();
            this.database = database;


            products = database.GetAllProductsFromDatabase();
            distinctTypes = database.GetDistinctTypes();
            distinctSuppliers = database.GetDistinctSuppliers();

            comboBoxName.DataSource = products;
            comboBoxName.DisplayMember = "Name";

            // Привязываем ComboBox к списку строк
            comboBoxType.DataSource = distinctTypes;
            comboBoxSupplier.DataSource = distinctSuppliers;

            comboBox1_SelectedIndexChanged(null, null);
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму
            this.Close();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            database.DeleteProduct(comboBoxName.SelectedValue.ToString());
            MessageBox.Show($"Товар '{comboBoxName.SelectedValue.ToString()}' успешно удалён");
            RefreshComboBoxName();
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                int typeId = database.GetTypeId(comboBoxType.Text);
                int supplierId = database.GetSupplierId(comboBoxSupplier.Text);
                // Проверка, есть ли уже в БД
                List<string> distictProductsName = database.GetDistinctProductNames();
                foreach (string name in distictProductsName)
                {
                    if (textBoxName.Text == name)
                    {
                        MessageBox.Show("Такой товар уже есть. Попробуйте ввести другой");
                        return;
                    }
                }
                //database.SendRequest($"INSERT INTO Products (Name, TypeID, SupplierID, Quantity, Cost, SupplyDate) VALUES\r\n    ('{textBoxName.Text}', {typeId}, {supplierId}, {numericUpDownQuantity.Value}, {numericUpDownCost.Value}, '{dateTimePicker.Value.ToString("yyyy-MM-dd")}');");

                if (comboBoxName.SelectedItem is Product selectedProduct)
                {
                    string query = $@"UPDATE Products 
                 SET 
                     Name = '{textBoxName.Text}', 
                     TypeID = '{database.GetTypeId(comboBoxType.SelectedItem.ToString())}',
                     SupplierID = '{database.GetSupplierId(comboBoxSupplier.SelectedItem.ToString())}',
                     Quantity = {Convert.ToInt32(numericUpDownQuantity.Value)}, 
                     Cost = {Convert.ToDecimal(numericUpDownCost.Value)}, 
                     SupplyDate = '{dateTimePicker.Value.ToString("yyyy-MM-dd")}' 
                 WHERE 
                     ID = {Convert.ToInt32(selectedProduct.ID)}";

                    database.SendRequest(query);
                }



                MessageBox.Show($"Товар '{textBoxName.Text}' успешно изменён в БД");
                RefreshComboBoxName();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
                return;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Проверка textBox
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                buttonChange.Enabled = false;
            }
            else buttonChange.Enabled = true;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что в ComboBox есть выбранный элемент и он является объектом типа Product
            if (comboBoxName.SelectedItem is Product selectedProduct)
            {
                // Устанавливаем текст в textBoxName равным выбранному Name
                textBoxName.Text = selectedProduct.Name;
                numericUpDownQuantity.Value = selectedProduct.Quantity;
                numericUpDownCost.Value = selectedProduct.Cost;
                dateTimePicker.Value = selectedProduct.SupplyDate;

                comboBoxType.SelectedItem = selectedProduct.TypeObj.Name;
                comboBoxSupplier.SelectedItem = selectedProduct.SupplierObj.Name;
            }
        }

        // Метод для обновления списка имён в comboBoxName
        private void RefreshComboBoxName()
        {
            // Получите уникальные имена из базы данных или другого источника данных и установите в качестве источника данных для comboBoxName
            products = database.GetAllProductsFromDatabase();

            // Привязка ComboBox к списку Name в объектах Product
            comboBoxName.DataSource = products;
            comboBoxName.DisplayMember = "Name";
        }
    }
}
