using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _14._02._2024_StationeryCompany.View;
using System.Reflection.Metadata.Ecma335;

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
            return database.ExecuteStoredProcedure("LoadProductInfo");
        }

        public DataTable LoadAllProductTypes()
        {
            return database.ExecuteStoredProcedure("LoadAllProductTypes");
        }

        public DataTable LoadAllSalesManagers()
        {
            return database.ExecuteStoredProcedure("LoadAllSalesManagers");
        }
        public DataTable LoadAllBuyingCompanies()
        {
            return database.ExecuteStoredProcedure("LoadAllBuyingCompanies");
        }





        public DataTable LoadProductsByMaxQuantity()
        {
            return database.ExecuteStoredProcedure("LoadProductsByMaxQuantity");
        }

        public DataTable LoadProductsByMinQuantity()
        {
            return database.ExecuteStoredProcedure("LoadProductsByMinQuantity");
        }

        public DataTable LoadProductsByMinCostPrice()
        {
            return database.ExecuteStoredProcedure("LoadProductsByMinCostPrice");
        }

        public DataTable LoadProductsByMaxCostPrice()
        {
            return database.ExecuteStoredProcedure("LoadProductsByMaxCostPrice");
        }

        public DataTable LoadRecentSale()
        {
            return database.ExecuteStoredProcedure("LoadRecentSale");
        }

        public DataTable LoadAverageQuantityByType()
        {
            return database.ExecuteStoredProcedure("LoadAverageQuantityByType");
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

















        public List<string> GetTableNames(ObjectType objectType)
        {
            switch (objectType)
            {
                case ObjectType.Manager:
                    return GetAllSalesManagers();
                case ObjectType.ProductType:
                    return GetAllProductTypes();
                case ObjectType.BuyingCompany:
                    return GetAllBuyingCompanies();
                default:
                    return new List<string>();
            }
        }



        public void UpdateManager(string managerName, string newManagerName)
        {
            database.ExecuteStoredProcedure("UpdateSalesManagerByName", managerName, newManagerName);
        }

        public void UpdateType(string typeName, string newTypeName)
        {
            database.ExecuteStoredProcedure("UpdateProductTypeByName", typeName, newTypeName);
        }

        public void UpdateCompany(string companyName, string newCompanyName)
        {
            database.ExecuteStoredProcedure("UpdateBuyingCompanyByName", companyName, newCompanyName);
        }


        public void AddCompany(string newName)
        {
            database.ExecuteStoredProcedure("AddCompany", newName);
        }
        public void AddProductType(string newName)
        {
            database.ExecuteStoredProcedure("AddProductType", newName);
        }
        public void AddManager(string newName)
        {
            database.ExecuteStoredProcedure("AddSalesManager", newName);
        }





        public void DeleteBuyingCompanyAndRelatedData(string name)
        {
            database.ExecuteStoredProcedure("DeleteCompanyAndSalesByName", name);
        }

        public void DeleteSalesManagerAndRelatedData(string name)
        {
            database.ExecuteStoredProcedure("DeleteSalesManagerAndSalesByName", name);
        }

        public void DeleteProductTypeAndRelatedData(string name)
        {
            database.ExecuteStoredProcedure("DeleteProductTypeAndProductsByName", name);
        }
    }
}
