using _19._02._2024_Detached_model;
using _19._02._2024_Detached_model.View;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _19._02._2024_Detached_model
{
    public partial class FormMain : Form
    {
        private DatabaseManager databaseManager;

        private IConfigurationRoot LoadConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public FormMain()
        {
            InitializeComponent();

            try
            {
                IConfigurationRoot config = LoadConfiguration();
                string connectionString = config.GetConnectionString("DefaultConnection");
                databaseManager = new DatabaseManager(connectionString);
                //databaseManager.InitializeData();
                dataGridView.DataSource = databaseManager.GetProductsDataTable();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }



        private void loadDatabaseFromSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                databaseManager.LoadDatabaseFromSource();
                ShowMessage("Успешно обновлено");
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void updateDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                databaseManager.UpdateDataSource();
                ShowMessage("Успешно обновлено");
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }







        private void DisplayTable(DataTable dataTable)
        {
            try
            {
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void DisplayProductTypes()
        {
            DisplayTable(databaseManager.GetProductTypesDataTable());
        }

        private void DisplaySuppliers()
        {
            DisplayTable(databaseManager.GetSuppliersDataTable());
        }

        private void DisplayProducts()
        {
            DisplayTable(databaseManager.GetProductsDataTable());
        }





        private void productTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayProductTypes();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void changeProductTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProductTypes formProductTypes = new FormProductTypes(databaseManager);
            formProductTypes.ShowDialog();
        }

        private void changeSuppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSuppliers formSuppliers = new FormSuppliers(databaseManager);
            formSuppliers.ShowDialog();
        }

        private void changeProductsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProducts formProducts = new FormProducts(databaseManager);
            formProducts.ShowDialog();
        }
    }
}