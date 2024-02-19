using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14._02._2024_StationeryCompany.Model
{
    public class DatabaseManager
    {
        private Database database;

        public DatabaseManager()
        {
            database = new Database();
        }
        public void ConnectToDatabase()
        {
            database.Connect();
        }

        public void DisconnectFromDatabase()
        {
            database.Disconnect();
        }

        public DataTable LoadProductInfo()
        {
            string query = "SELECT * FROM ProductInfoView";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadAllProductTypes()
        {
            string query = "SELECT * FROM ProductTypes";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadAllSalesManagers()
        {
            string query = "SELECT * FROM SalesManagers";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadProductsByMaxQuantity()
        {
            string query = "SELECT * FROM ProductInfoView WHERE Quantity = (SELECT MAX(Quantity) FROM ProductInfoView)";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadProductsByMinQuantity()
        {
            string query = "SELECT * FROM ProductInfoView WHERE Quantity = (SELECT MIN(Quantity) FROM ProductInfoView)";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadProductsByMinCostPrice()
        {
            string query = "SELECT * FROM ProductInfoView WHERE CostPrice = (SELECT MIN(CostPrice) FROM ProductInfoView)";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadProductsByMaxCostPrice()
        {
            string query = "SELECT * FROM ProductInfoView WHERE CostPrice = (SELECT MAX(CostPrice) FROM ProductInfoView)";
            return database.ExecuteQuery(query);
        }









        public List<string> GetAllProductTypes()
        {
            string query = "SELECT TypeName FROM ProductTypes";
            DataTable result = database.ExecuteQuery(query);

            // Преобразуем DataTable в List<string>
            List<string> productTypes = result.AsEnumerable()
                                            .Select(row => row.Field<string>("TypeName"))
                                            .ToList();

            return productTypes;
        }
        public DataTable LoadProductsByType(string selectedType)
        {
            // Загружаем канцтовары выбранного типа
            string query = $"SELECT * FROM ProductInfoView WHERE ProductType = '{selectedType}'";
            return database.ExecuteQuery(query);
        }






        public List<string> GetAllSalesManagers()
        {
            string query = "SELECT ManagerName FROM SalesManagers";
            DataTable result = database.ExecuteQuery(query);

            // Преобразуем DataTable в List<string>
            List<string> salesManagers = result.AsEnumerable()
                                               .Select(row => row.Field<string>("ManagerName"))
                                               .ToList();

            return salesManagers;
        }
        public DataTable LoadProductsBySalesManager(string selectedManager)
        {
            // Загружаем канцтовары, проданные выбранным менеджером
            string query = $"SELECT * FROM ProductInfoView WHERE SalesManager = '{selectedManager}'";
            return database.ExecuteQuery(query);
        }







        public List<string> GetAllBuyingCompanies()
        {
            string query = "SELECT CompanyName FROM BuyingCompanies";
            DataTable result = database.ExecuteQuery(query);

            // Преобразуем DataTable в List<string>
            List<string> buyingCompanies = result.AsEnumerable()
                                                 .Select(row => row.Field<string>("CompanyName"))
                                                 .ToList();

            return buyingCompanies;
        }

        public DataTable LoadProductsByBuyingCompany(string selectedCompany)
        {
            // Загружаем канцтовары, купленные выбранной фирмой
            string query = $"SELECT * FROM ProductInfoView WHERE BuyingCompany = '{selectedCompany}'";
            return database.ExecuteQuery(query);
        }



        public DataTable LoadRecentSale()
        {
            string query = "SELECT * FROM RecentSaleView";
            return database.ExecuteQuery(query);
        }

        public DataTable LoadAverageQuantityByType()
        {
            string query = "SELECT * FROM AverageQuantityByTypeView";
            return database.ExecuteQuery(query);
        }

    }
}
