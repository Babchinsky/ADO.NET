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
            dataGridView1.DataSource = databaseManager.LoadProductsByMinCostPrice();
        }
        private void сМинимальнойСебестоимостьюЕдиницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadProductsByMaxCostPrice();
        }


        private void информациюОСамойНедавнейПродажеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadRecentSale();
        }
        private void среднееКоличествоТоваровПоКаждомуТипуКантоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = databaseManager.LoadAverageQuantityByType();
        }









        //private void заданногоТипаToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Загружаем все типы канцтоваров
        //    List<string> productTypes = databaseManager.GetAllProductTypes();

        //    // Создаем форму выбора типа
        //    using (TypeSelectionForm typeSelectionForm = new TypeSelectionForm(productTypes))
        //    {
        //        // Подписываемся на событие выбора типа
        //        typeSelectionForm.TypeSelected += TypeSelectionForm_TypeSelected;

        //        // Открываем форму выбора типа
        //        typeSelectionForm.ShowDialog();
        //    }
        //}

        //private void TypeSelectionForm_TypeSelected(object sender, string selectedType)
        //{
        //    if (!string.IsNullOrEmpty(selectedType))
        //    {
        //        DataTable productsByType = databaseManager.LoadProductsByType(selectedType);
        //        dataGridView1.DataSource = productsByType;
        //    }
        //}





        //private void которыеПродалКонкретныйМенеджерПоПрадажамToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Загружаем всех менеджеров по продажам
        //    List<string> salesManagers = databaseManager.GetAllSalesManagers();

        //    // Создаем форму выбора менеджера
        //    using (SalesManagerSelectionForm salesManagerSelectionForm = new SalesManagerSelectionForm(salesManagers))
        //    {
        //        // Подписываемся на событие выбора менеджера
        //        salesManagerSelectionForm.ManagerSelected += SalesManagerSelectionForm_ManagerSelected;

        //        // Открываем форму выбора менеджера
        //        salesManagerSelectionForm.ShowDialog();
        //    }
        //}
        //private void SalesManagerSelectionForm_ManagerSelected(object sender, string selectedManager)
        //{
        //    if (!string.IsNullOrEmpty(selectedManager))
        //    {
        //        DataTable productsBySalesManager = databaseManager.LoadProductsBySalesManager(selectedManager);
        //        dataGridView1.DataSource = productsBySalesManager;
        //    }
        //}

        //private void которыеКупилаКонкретнаяФирмаПокупательToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Загружаем все фирмы-покупатели
        //    List<string> buyingCompanies = databaseManager.GetAllBuyingCompanies();

        //    // Создаем форму выбора фирмы
        //    using (BuyingCompanySelectionForm buyingCompanySelectionForm = new BuyingCompanySelectionForm(buyingCompanies))
        //    {
        //        // Подписываемся на событие выбора фирмы
        //        buyingCompanySelectionForm.CompanySelected += BuyingCompanySelectionForm_CompanySelected;

        //        // Открываем форму выбора фирмы
        //        buyingCompanySelectionForm.ShowDialog();
        //    }
        //}
        //private void BuyingCompanySelectionForm_CompanySelected(object sender, string selectedCompany)
        //{
        //    if (!string.IsNullOrEmpty(selectedCompany))
        //    {
        //        DataTable productsByBuyingCompany = databaseManager.LoadProductsByBuyingCompany(selectedCompany);
        //        dataGridView1.DataSource = productsByBuyingCompany;
        //    }
        //}






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

        // ... (остальной код)





    }
}
