using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace _14._02._2024_StationeryCompany.View
{
    public partial class GenericSelectionForm : Form
    {
        private List<string> itemList;

        public event EventHandler<string> ItemSelected;

        public GenericSelectionForm(List<string> items)
        {
            InitializeComponent();
            itemList = items;

            // Заполнить элементы управления данными
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            comboBoxItems.DataSource = itemList;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбран какой-то элемент
            if (comboBoxItems.SelectedIndex != -1)
            {
                // Вызываем событие и передаем выбранный элемент
                ItemSelected?.Invoke(this, comboBoxItems.SelectedItem.ToString());
                this.Close(); // Закрываем форму после выбора элемента
            }
        }
    }


}
