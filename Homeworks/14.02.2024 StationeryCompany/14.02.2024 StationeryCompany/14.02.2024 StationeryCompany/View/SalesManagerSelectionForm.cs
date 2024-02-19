using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14._02._2024_StationeryCompany.View
{
    public partial class SalesManagerSelectionForm : Form
    {
        // В этом событии будет передаваться выбранный менеджер по продажам
        public event EventHandler<string> ManagerSelected;

        public SalesManagerSelectionForm(List<string> salesManagers)
        {
            InitializeComponent();

            // Заполняем ComboBox менеджерами по продажам
            comboBoxSalesManagers.DataSource = salesManagers;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Передаем выбранного менеджера в основную форму
            ManagerSelected?.Invoke(this, comboBoxSalesManagers.SelectedItem?.ToString());
            Close();
        }
    }
}
