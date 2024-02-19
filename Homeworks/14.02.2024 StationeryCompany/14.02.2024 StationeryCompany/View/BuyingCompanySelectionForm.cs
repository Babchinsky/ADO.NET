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
    public partial class BuyingCompanySelectionForm : Form
    {
        // В этом событии будет передаваться выбранная фирма-покупатель
        public event EventHandler<string> CompanySelected;

        public BuyingCompanySelectionForm(List<string> buyingCompanies)
        {
            InitializeComponent();

            // Заполняем ComboBox фирмами-покупателями
            comboBoxBuyingCompanies.DataSource = buyingCompanies;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Передаем выбранную фирму-покупателя в основную форму
            CompanySelected?.Invoke(this, comboBoxBuyingCompanies.SelectedItem?.ToString());
            Close();
        }
    }
}
