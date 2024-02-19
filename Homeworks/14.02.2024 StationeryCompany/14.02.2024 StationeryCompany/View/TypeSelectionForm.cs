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
    public partial class TypeSelectionForm : Form
    {
        // В этом событии будет передаваться выбранный тип канцтоваров
        public event EventHandler<string> TypeSelected;

        public TypeSelectionForm(List<string> productTypes)
        {
            InitializeComponent();

            // Заполняем ComboBox типами канцтоваров
            comboBoxProductTypes.DataSource = productTypes;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Передаем выбранный тип в основную форму
            TypeSelected?.Invoke(this, comboBoxProductTypes.SelectedItem?.ToString());
            Close();
        }
    }
}
