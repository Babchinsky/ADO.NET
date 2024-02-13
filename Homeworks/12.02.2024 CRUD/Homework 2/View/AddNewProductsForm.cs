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
    public partial class AddNewProductsForm : Form
    {
        Database database;
        List<string> distinctSuppliers;
        List<string> distinctTypes;
        public AddNewProductsForm(Database database)
        {
            InitializeComponent();
            this.database = database;

            distinctTypes = database.GetDistinctTypes();
            distinctSuppliers = database.GetDistinctSuppliers();

            // Привязываем ComboBox к списку строк
            comboBoxType.DataSource = distinctTypes;
            comboBoxSupplier.DataSource = distinctSuppliers;
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму
            this.Close();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            

            //database.SendRequest($"INSERT INTO Products (Name, TypeID, SupplierID, Quantity, Cost, SupplyDate) VALUES\r\n    ('{textBoxName.Text}', {typeId}, {supplierId}, {numericUpDownQuantity.Value}, {numericUpDownCost.Value}, '{dateTimePicker.Value.ToString("yyyy-MM-dd")}');");


            //MessageBox.Show($"Товар '{textBoxName.Text}' успешно добавлен в БД");


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
                database.SendRequest($"INSERT INTO Products (Name, TypeID, SupplierID, Quantity, Cost, SupplyDate) VALUES\r\n    ('{textBoxName.Text}', {typeId}, {supplierId}, {numericUpDownQuantity.Value}, {numericUpDownCost.Value}, '{dateTimePicker.Value.ToString("yyyy-MM-dd")}');");
                MessageBox.Show($"Товара '{textBoxName.Text}' успешно добавлен в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Проверка textBox
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                buttonAdd.Enabled = false;
            }
            else buttonAdd.Enabled = true;
        }

    }
}
