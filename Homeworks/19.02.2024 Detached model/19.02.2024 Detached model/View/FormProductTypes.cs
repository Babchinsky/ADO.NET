using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19._02._2024_Detached_model.View
{
    public partial class FormProductTypes : Form
    {
        DatabaseManager databaseManager;
        public FormProductTypes(DatabaseManager databaseManager)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            // Получение DataTable с типами продуктов
            DataTable productTypesTable = databaseManager.GetProductTypesDataTable();

            // Задание источника данных для ComboBox
            comboBoxName.DataSource = productTypesTable;
            comboBoxName.DisplayMember = "Name";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            databaseManager.DeleteProductTypeByName(comboBoxName.Text);
            UpdateComboBox();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            databaseManager.UpdateProductTypeByName(comboBoxName.Text, textBoxName.Text);
            UpdateComboBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            databaseManager.AddProductType(textBoxName.Text);
            UpdateComboBox();
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxName.SelectedItem != null)
            {
                // Получаем текущую строку из DataTable
                DataRowView selectedRow = comboBoxName.SelectedItem as DataRowView;

                // Проверяем, что строка не пуста
                if (selectedRow != null)
                {
                    // Получаем значение столбца "Name" из выбранной строки и устанавливаем его в textBox
                    textBoxName.Text = selectedRow["Name"].ToString();
                }
            }
        }
    }
}
