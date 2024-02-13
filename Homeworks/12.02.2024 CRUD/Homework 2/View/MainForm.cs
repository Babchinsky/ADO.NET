using Homework_2.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Homework_3
{
    public partial class MainForm : Form
    {
        Database database;
        public MainForm()
        {
            InitializeComponent();
            database = new Database(this);

            // Добавляем обработчик события FormClosing
            this.FormClosing += MainForm_FormClosing;

            database.Connect();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Выполняйте здесь действия, которые должны быть выполнены при закрытии программы
            if (database.isConnected == true) database.Disconnect();
        }

        public void SetGridView(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            database.ShowAllProducts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            database.ShowAllTypes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            database.ShowAllSuppliers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMaxQuantity();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMinQuantity();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMinCost();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMaxCost();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            database.ShowOldestProduct();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            database.ShowAverageQuantityByProductType();
        }

        private void insertingNewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewProductsForm addNewProductsForm = new AddNewProductsForm(database);
            addNewProductsForm.ShowDialog();
        }

        private void insertingNewTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTypesForm addNewTypesForm = new AddNewTypesForm(database);
            addNewTypesForm.ShowDialog();
        }

        private void insertingNewSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSuppliersForm addNewSuppliersForm = new AddNewSuppliersForm(database);
            addNewSuppliersForm.ShowDialog();
        }

        private void updateProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProductsForm updateProductsForm = new UpdateProductsForm(database);
            updateProductsForm.ShowDialog();
        }

        private void updateTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTypesForm updateTypesForm = new UpdateTypesForm(database);
            updateTypesForm.ShowDialog();
        }

        private void updateSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSuppliersForm updateSuppliersForm = new UpdateSuppliersForm(database);
            updateSuppliersForm.ShowDialog();
        }









        private void viewEntireWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowAllProducts();
        }

        private void viewAllProductTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowAllTypes();
        }

        private void viewAllSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowAllSuppliers();
        }

        private void среднееКолToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowAverageQuantityByProductType();
        }

        private void сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowSupplierWithMaxProducts();
        }

        private void сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowSupplierWithMinProducts();
        }

        private void сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            database.ShowTypeWithMaxProducts();
        }

        private void сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            database.ShowSupplierWithMinProducts();
        }

        private void сНаибольшимКоличествомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMaxQuantity();
        }

        private void сНаименьшимКоличествомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMinQuantity();
        }

        private void сНаибольшейСебестоимостьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMaxCost();
        }

        private void сНаименьшейСебестоимостьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowProductWithMinCost();
        }

        private void самыйСтарыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ShowOldestProduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.ShowProductsByDaysAgo(Convert.ToInt32(numericUpDown1.Value));
        }
    }
}
