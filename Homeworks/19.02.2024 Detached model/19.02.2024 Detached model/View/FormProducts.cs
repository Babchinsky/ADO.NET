using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19._02._2024_Detached_model
{
    public partial class FormProducts : Form
    {
        DatabaseManager databaseManager;
        public FormProducts(DatabaseManager databaseManager)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            InitializeData();
            comboBoxName.SelectedIndex = 1;
        }
        public void InitializeData()
        {
            InitializeTypes();
            InitializeSuppliers();
            InitializeNames();
        }
        public void InitializeNames()
        {
            // Получение DataTable с типами продуктов
            DataTable namesTable = databaseManager.GetProductsDataTable();

            // Задание источника данных для ComboBox
            comboBoxName.DataSource = namesTable;
            comboBoxName.DisplayMember = "Name";
            //comboBoxName.ValueMember = "ID";
        }

        public void InitializeTypes()
        {
            // Получение DataTable с типами продуктов
            DataTable productTypesTable = databaseManager.GetProductTypesDataTable();

            // Задание источника данных для ComboBox
            comboBoxType.DataSource = productTypesTable;
            comboBoxType.DisplayMember = "Name";
            //comboBoxType.ValueMember = "ID";
        }

        public void InitializeSuppliers()
        {
            // Получение DataTable с типами продуктов
            DataTable suppliersTable = databaseManager.GetSuppliersDataTable();

            // Задание источника данных для ComboBox
            comboBoxSupplier.DataSource = suppliersTable;
            comboBoxSupplier.DisplayMember = "Name";
            //comboBoxSupplier.ValueMember = "ID";
        }


        public void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получение выбранного продукта
            string selectedProductName = comboBoxName.Text;
            

            // Находим соответствующую строку в таблице Products
            DataRow[] rows = databaseManager.dataSet.Tables["Products"].Select($"Name = '{selectedProductName}'");

            if (rows.Length > 0)
            {
                DataRow selectedProduct = rows[0];
                textBoxNewName.Text = selectedProductName;


                // Получение ID типа продукта и поставщика из выбранного продукта
                int typeId = Convert.ToInt32(selectedProduct["TypeID"]);
                int supplierId = Convert.ToInt32(selectedProduct["SupplierID"]);

                // Находим соответствующие строки в таблицах ProductTypes и Suppliers
                DataRow[] typeRows = databaseManager.dataSet.Tables["ProductTypes"].Select($"ID = {typeId}");
                DataRow[] supplierRows = databaseManager.dataSet.Tables["Suppliers"].Select($"ID = {supplierId}");

                // Обновление элементов формы значениями из выбранного продукта
                if (typeRows.Length > 0)
                    comboBoxType.Text = typeRows[0]["Name"].ToString();
                else
                    comboBoxType.Text = string.Empty;

                if (supplierRows.Length > 0)
                    comboBoxSupplier.Text = supplierRows[0]["Name"].ToString();
                else
                    comboBoxSupplier.Text = string.Empty;

                numericUpDownQuantity.Value = Convert.ToDecimal(selectedProduct["Quantity"]);
                numericUpDownCost.Value = Convert.ToDecimal(selectedProduct["Cost"]);
                dateTimePicker.Value = Convert.ToDateTime(selectedProduct["SupplyDate"]);
            }
            else
            {
                // Очистка элементов формы, если продукт не найден
                comboBoxType.Text = string.Empty;
                comboBoxSupplier.Text = string.Empty;
                numericUpDownQuantity.Value = 0;
                numericUpDownCost.Value = 0;
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Получение данных из элементов формы
            string name = textBoxNewName.Text;
            string type = comboBoxType.Text;
            string supplier = comboBoxSupplier.Text;
            decimal quantity = numericUpDownQuantity.Value;
            decimal cost = numericUpDownCost.Value;
            DateTime supplyDate = dateTimePicker.Value;

            // Вызов метода AddProduct, передав параметры
            databaseManager.AddProduct(name, type, supplier, quantity, cost, supplyDate);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            // Получение данных из элементов формы
            string name = comboBoxName.Text; // старое имя продукта
            string newName = textBoxNewName.Text; // новое имя продукта
            string type = comboBoxType.Text;
            string supplier = comboBoxSupplier.Text;
            decimal quantity = numericUpDownQuantity.Value;
            decimal cost = numericUpDownCost.Value;
            DateTime supplyDate = dateTimePicker.Value;

            // Вызов метода UpdateProduct, передав параметры
            databaseManager.UpdateProduct(name, newName, type, supplier, quantity, cost, supplyDate);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            databaseManager.DeleteProduct(comboBoxName.Text);
        }
    }
}
