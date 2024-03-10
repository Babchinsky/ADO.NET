using _14._02._2024_StationeryCompany.Model;
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
    public enum ObjectType
    {
        Manager,
        ProductType,
        BuyingCompany
    }



    public partial class UpdateRecordForm : Form
    {
        DatabaseManager databaseManager;
        ObjectType objectType;

        public UpdateRecordForm(DatabaseManager databaseManager, ObjectType objectType)
        {
            InitializeComponent();
            this.objectType = objectType;
            this.databaseManager = databaseManager;

            switch (objectType)
            {
                case ObjectType.Manager:
                    this.Text = "Изменение менеджеров";
                    break;
                case ObjectType.ProductType:
                    this.Text = "Изменение типов канцтоваров";
                    break;
                case ObjectType.BuyingCompany:
                    this.Text = "Изменение покупающих компаний";
                    break;
            }

            FillComboBox();
        }

        public void FillComboBox()
        {
            comboBoxSelect.DataSource = databaseManager.GetTableNames(objectType);
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxNew.Text = comboBoxSelect.Text;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try 
            {
                switch (objectType)
                {
                    case ObjectType.Manager:
                        databaseManager.UpdateManager(comboBoxSelect.Text, textBoxNew.Text); break;
                    case ObjectType.BuyingCompany:
                        databaseManager.UpdateCompany(comboBoxSelect.Text, textBoxNew.Text); break;
                    case ObjectType.ProductType:
                        databaseManager.UpdateType(comboBoxSelect.Text, textBoxNew.Text); break;
                }
                //FillComboBox();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка " + ex.Message);
            }
            FillComboBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                switch (objectType)
                {
                    case ObjectType.Manager:
                        databaseManager.AddManager(textBoxNew.Text); break;
                    case ObjectType.BuyingCompany:
                        databaseManager.AddCompany(textBoxNew.Text); break;
                    case ObjectType.ProductType:
                        databaseManager.AddProductType(textBoxNew.Text); break;
                }
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка " + ex.Message);
            }
            FillComboBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (objectType)
                {
                    case ObjectType.Manager:
                        databaseManager.DeleteSalesManagerAndRelatedData(comboBoxSelect.Text); break;
                    case ObjectType.BuyingCompany:
                        databaseManager.DeleteBuyingCompanyAndRelatedData(comboBoxSelect.Text); break;
                    case ObjectType.ProductType:
                        databaseManager.DeleteProductTypeAndRelatedData(comboBoxSelect.Text); break;
                }
                //FillComboBox();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка " + ex.Message);
            }
            FillComboBox();
        }
    }

}
