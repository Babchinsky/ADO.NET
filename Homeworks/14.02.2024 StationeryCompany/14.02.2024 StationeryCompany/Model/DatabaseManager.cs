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








        public List<string> GetAllItemsFromTable(string tableName, string columnName)
        {
            string query = $"SELECT {columnName} FROM {tableName}";
            DataTable result = database.ExecuteQuery(query);

            // Преобразуем DataTable в List<string>
            List<string> items = result.AsEnumerable()
                                        .Select(row => row.Field<string>(columnName))
                                        .ToList();

            return items;
        }

        public List<string> GetAllProductTypes()
        {
            return GetAllItemsFromTable("ProductTypes", "TypeName");
        }

        public List<string> GetAllSalesManagers()
        {
            return GetAllItemsFromTable("SalesManagers", "ManagerName");
        }

        public List<string> GetAllBuyingCompanies()
        {
            return GetAllItemsFromTable("BuyingCompanies", "CompanyName");
        }









        public DataTable LoadProductsByType(string productType)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ProductType", productType }
            };
            return database.ExecuteStoredProcedure("GetProductsByType", parameters);
        }
        public DataTable LoadProductsBySalesManager(string salesManager)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SalesManager", salesManager }
            };
            return database.ExecuteStoredProcedure("GetProductsBySalesManager", parameters);
        }
        public DataTable LoadProductsByBuyingCompany(string buyingCompany)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@BuyingCompany", buyingCompany }
            };
            return database.ExecuteStoredProcedure("GetProductsByBuyingCompany", parameters);
        }
    }
}
