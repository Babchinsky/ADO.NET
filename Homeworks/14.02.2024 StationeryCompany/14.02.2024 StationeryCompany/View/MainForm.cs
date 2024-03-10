using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using _14._02._2024_StationeryCompany.Model;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _14._02._2024_StationeryCompany.View
{
    public partial class MainForm : Form
    {
        DatabaseManager databaseManager;

        public MainForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();

            // Добавляем обработчик события FormClosing
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            databaseManager.ConnectToDatabase();

            // Загрузка данных о канцтоварах при загрузке формы
            dataGridView1.DataSource = databaseManager.LoadProductInfo();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            databaseManager.DisconnectFromDatabase();
        }




        private void всюИнформациюОКантоварахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductInfo();
        }

        private void всеТипыКантоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadAllProductTypes();
        }

        private void всехМенеджеровПоПродажамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadAllSalesManagers();
        }
        private void всеКомпанииПокупателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadAllBuyingCompanies();
        }


        private void сМаксимальнымКолиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductsByMaxQuantity();
        }

        private void сМинимальнымКолвомЕдиницToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductsByMinQuantity();
        }

        private void сМаксимальнойСебестоимостьюЕдиницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductsByMaxCostPrice();
        }
        private void сМинимальнойСебестоимостьюЕдиницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductsByMinCostPrice();
        }


        private void информациюОСамойНедавнейПродажеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadRecentSale();
        }
        private void среднееКоличествоТоваровПоКаждомуТипуКантоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadAverageQuantityByType();
        }









        private void ShowSelectionForm(List<string> items, EventHandler<string> selectionHandler)
        {
            using (GenericSelectionForm selectionForm = new GenericSelectionForm(items))
            {
                selectionForm.ItemSelected += selectionHandler;
                selectionForm.ShowDialog();
            }
        }




        private void GenericSelectionForm_TypeSelected(object sender, string selectedValue)
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable productsByType = databaseManager.LoadProductsByType(selectedValue);
                dataGridView1.DataSource = productsByType;
            }
        }

        private void GenericSelectionForm_ManagerSelected(object sender, string selectedValue)
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable productsBySalesManager = databaseManager.LoadProductsBySalesManager(selectedValue);
                dataGridView1.DataSource = productsBySalesManager;
            }
        }

        private void GenericSelectionForm_CompanySelected(object sender, string selectedValue)
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable productsByBuyingCompany = databaseManager.LoadProductsByBuyingCompany(selectedValue);
                dataGridView1.DataSource = productsByBuyingCompany;
            }
        }
        private void заданногоТипаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> productTypes = databaseManager.GetAllProductTypes();
            ShowSelectionForm(productTypes, GenericSelectionForm_TypeSelected);
        }

        private void которыеПродалКонкретныйМенеджерПоПрадажамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> salesManagers = databaseManager.GetAllSalesManagers();
            ShowSelectionForm(salesManagers, GenericSelectionForm_ManagerSelected);
        }

        private void которыеКупилаКонкретнаяФирмаПокупательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> buyingCompanies = databaseManager.GetAllBuyingCompanies();
            ShowSelectionForm(buyingCompanies, GenericSelectionForm_CompanySelected);
        }
































        //private void OpenUpdateRecordForm(string tableName, string columnName)
        //{
        //    using (UpdateRecordForm updateForm = new UpdateRecordForm(databaseManager, tableName, columnName))
        //    {
        //        updateForm.ShowDialog();
        //    }
        //}

        private void OpenUpdateRecordForm(DatabaseManager databaseManager, ObjectType objectType)
        {
            using (UpdateRecordForm updateForm = new UpdateRecordForm(databaseManager, objectType))
            {
                updateForm.ShowDialog();
            }
        }

        private void фирмыПокупателиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //OpenUpdateRecordForm("BuyingCompanies", "CompanyName");
            OpenUpdateRecordForm(databaseManager, ObjectType.BuyingCompany);
        }

        private void типыКанцтоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //OpenUpdateRecordForm("ProductTypes", "TypeName");
            OpenUpdateRecordForm(databaseManager, ObjectType.ProductType);

        }

        private void менеджеровПоПродажеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenUpdateRecordForm("SalesManagers", "ManagerName");
            OpenUpdateRecordForm(databaseManager, ObjectType.Manager);

        }
    }
}
