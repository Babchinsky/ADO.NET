using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_3;

namespace Homework_2.Model
{
    public class Database
    {
        private MainForm? formInstance;
        private string? connectionString;
        private SqlConnection? connect;
        private SqlCommand? command;

        public bool isConnected = false;

        public Database(MainForm form)
        {
            formInstance = form;
            // Создайте конфигурацию
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Читайте значение из файла конфигурации
            AppSettings appSettings = new AppSettings();
            config.GetSection("ConnectionStrings").Bind(appSettings);

            connectionString = appSettings.DefaultConnection;
        }

        public void Connect()
        {
            try
            {
                connect = new SqlConnection(connectionString);
                command = new SqlCommand();

                connect.Open();
                command.Connection = connect;

                isConnected = true;
                //MessageBox.Show("Вы успешно подключились к БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при подключении к БД. " + ex.Message);
                return;
            }
        }
        public void Disconnect()
        {
            try
            {
                command?.Dispose();
                connect?.Close();

                isConnected = false;
                //MessageBox.Show("Вы успешно отключились от БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при отключении от БД. " + ex.Message);
                return;
            }
        }

        public void SendRequest(string request)
        {
            try
            {
                command.CommandText = request;
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                formInstance?.SetGridView(dt);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
                return;
            }
        }
        public void SendParameterizedRequest(string query, SqlParameter parameter)
        {
            try
            {
                command.CommandText = query;

                // Добавление параметра в команду
                command.Parameters.Add(parameter);

                // Выполнение запроса
                command.ExecuteNonQuery();

                // Очистка параметров после выполнения запроса
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<string> GetDistinctTypes()
        {
            List<string> distinctTypes = new List<string>();
            try
            {
                command.CommandText = "SELECT DISTINCT Name FROM ProductTypes;";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string type = reader["Name"].ToString();
                    distinctTypes.Add(type);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
                return new List<string>();
            }

            return distinctTypes;
        }
        public List<string> GetDistinctSuppliers()
        {
            List<string> distinctSuppliers = new List<string>();
            try
            {
                command.CommandText = "SELECT DISTINCT Name FROM Suppliers;";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string supplier = reader["Name"].ToString();
                    distinctSuppliers.Add(supplier);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
                return new List<string>();
            }

            return distinctSuppliers;
        }
        public List<string> GetDistinctProductNames()
        {
            List<string> distinctProductNames = new List<string>();
            try
            {
                command.CommandText = "SELECT DISTINCT Name FROM Products;";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productName = reader["Name"].ToString();
                    distinctProductNames.Add(productName);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка " + ex.Message);
                return new List<string>();
            }

            return distinctProductNames;
        }
        public List<Product> GetAllProductsFromDatabase()
        {
            List<Product> productList = new List<Product>();

            command.CommandText = @"SELECT 
                                    P.ID, 
                                    P.Name, 
                                    P.Quantity, 
                                    P.Cost, 
                                    P.SupplyDate,
                                    T.ID AS TypeID,
                                    T.Name AS TypeName,
                                    S.ID AS SupplierID,
                                    S.Name AS SupplierName
                                FROM Products P
                                INNER JOIN ProductTypes T ON P.TypeID = T.ID
                                INNER JOIN Suppliers S ON P.SupplierID = S.ID";

            //command.CommandText = "SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate\r\nFROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID;";



            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Cost = Convert.ToDecimal(reader["Cost"]),
                        SupplyDate = Convert.ToDateTime(reader["SupplyDate"]),
                        TypeObj = new ProductType
                        {
                            ID = Convert.ToInt32(reader["TypeID"]),
                            Name = Convert.ToString(reader["TypeName"])
                        },
                        SupplierObj = new Supplier
                        {
                            ID = Convert.ToInt32(reader["SupplierID"]),
                            Name = Convert.ToString(reader["SupplierName"])
                        }
                    };


                    productList.Add(product);
                }
            }

            return productList;
        }
        public List<ProductType> GetProductTypes()
        {
            List<ProductType> productTypesList = new List<ProductType>();

            command.CommandText = "SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate\r\nFROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID;";


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductType productType = new ProductType
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    };

                    productTypesList.Add(productType);
                }
            }


            return productTypesList;
        }
        public int GetTypeId(string typeName)
        {
            int typeId = -1; // Возвращаемое значение, если тип не найден

            command.CommandText = "SELECT ID FROM ProductTypes WHERE Name = @TypeName";

            command.Parameters.AddWithValue("@TypeName", typeName);

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                typeId = Convert.ToInt32(result);
            }

            // Явно очистите параметры (не обязательно, так как они автоматически освободятся после выполнения)
            command.Parameters.Clear();
            return typeId;
        }
        public int GetSupplierId(string supplierName)
        {
            int supplierId = -1; // Возвращаемое значение, если тип не найден

            command.CommandText = "SELECT ID FROM Suppliers WHERE Name = @SupplierName";

            command.Parameters.AddWithValue("@SupplierName", supplierName);

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                supplierId = Convert.ToInt32(result);
            }
            // Явно очистите параметры (не обязательно, так как они автоматически освободятся после выполнения)
            command.Parameters.Clear();
            return supplierId;
        }


        public void DeleteProduct(string productNameToDelete)
        {
            string query = @"DELETE FROM Products
                      WHERE Name = @ProductName";
            try
            {
                // Ваш код для выполнения параметризованного запроса в базе данных
                // Используйте параметры для передачи значений в запрос
                SendParameterizedRequest(query, new SqlParameter("@ProductName", productNameToDelete));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении " + ex.Message);
            }
        }
        public void DeleteTypeWithConnectedProducts(string productTypeToDelete)
        {
            // SQL-запрос для удаления всех продуктов, связанных с указанным типом
            string deleteProductsQuery = $@"DELETE FROM Products
                                   WHERE TypeID IN (SELECT ID FROM ProductTypes WHERE Name = @ProductTypeToDelete)";

            // SQL-запрос для удаления самого типа продукта
            string deleteTypeQuery = "DELETE FROM ProductTypes WHERE Name = @ProductTypeToDelete";


            using (SqlTransaction transaction = connect.BeginTransaction())
            {
                try
                {
                    // Удаление продуктов связанных с указанным типом
                    using (SqlCommand command = new SqlCommand(deleteProductsQuery, connect, transaction))
                    {
                        command.Parameters.AddWithValue("@ProductTypeToDelete", productTypeToDelete);
                        command.ExecuteNonQuery();
                    }
            
                    // Удаление самого типа продукта
                    using (SqlCommand command = new SqlCommand(deleteTypeQuery, connect, transaction))
                    {
                        command.Parameters.AddWithValue("@ProductTypeToDelete", productTypeToDelete);
                        command.ExecuteNonQuery();
                    }
            
                    // Если всё прошло успешно, подтверждаем транзакцию
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Если возникла ошибка, откатываем транзакцию
                    transaction.Rollback();
                    MessageBox.Show("Ошибка при удалении типа продукта: " + ex.Message);
                }
            }
            
        }
        public void DeleteSupplierWithConnectedProducts(string supplierToDelete)
        {
            // SQL-запрос для удаления всех продуктов, связанных с указанным поставщиком
            string deleteProductsQuery = $@"DELETE FROM Products
                                    WHERE SupplierID IN (SELECT ID FROM Suppliers WHERE Name = @SupplierToDelete)";

            // SQL-запрос для удаления самого поставщика
            string deleteSupplierQuery = "DELETE FROM Suppliers WHERE Name = @SupplierToDelete";


            using (SqlTransaction transaction = connect.BeginTransaction())
            {
                try
                {
                    // Удаление продуктов связанных с указанным типом
                    using (SqlCommand command = new SqlCommand(deleteProductsQuery, connect, transaction))
                    {
                        command.Parameters.AddWithValue("@SupplierToDelete", supplierToDelete);
                        command.ExecuteNonQuery();
                    }

                    // Удаление самого типа продукта
                    using (SqlCommand command = new SqlCommand(deleteSupplierQuery, connect, transaction))
                    {
                        command.Parameters.AddWithValue("@SupplierToDelete", supplierToDelete);
                        command.ExecuteNonQuery();
                    }

                    // Если всё прошло успешно, подтверждаем транзакцию
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Если возникла ошибка, откатываем транзакцию
                    transaction.Rollback();
                    MessageBox.Show("Ошибка при удалении поставщика: " + ex.Message);
                }
            }

        }





        public void ShowAllProducts()
        {
            string query = "SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate\r\n\t" +
                "FROM Products\r\n\t" +
                "JOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\n\t" +
                "JOIN Suppliers ON Products.SupplierID = Suppliers.ID;";
            SendRequest(query);
        }
        public void ShowAllTypes()
        {
            SendRequest("SELECT DISTINCT ID, Name FROM ProductTypes;");
        }
        public void ShowAllSuppliers()
        {
            SendRequest("SELECT DISTINCT ID, Name FROM Suppliers;");
        }
        public void ShowProductWithMaxQuantity()
        {
            SendRequest("SELECT TOP 1 * FROM Products \r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nORDER BY Quantity DESC");
        }
        public void ShowProductWithMinQuantity()
        {
            SendRequest("SELECT TOP 1 * FROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nORDER BY Quantity ASC");
        }
        public void ShowProductWithMinCost()
        {
            SendRequest("SELECT TOP 1 * FROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nORDER BY Cost ASC");
        }
        public void ShowProductWithMaxCost()
        {
            SendRequest("SELECT TOP 1 * FROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nORDER BY Cost DESC");
        }
        public void ShowProductsByCategory(string category)
        {
            SendRequest($"SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate\r\nFROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nWHERE ProductTypes.Name = '{category}';");
        }
        public void ShowProductsBySupplier(string supplier)
        {
            SendRequest($"SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate\r\nFROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nWHERE Suppliers.Name = '{supplier}';");
        }
        public void ShowOldestProduct()
        {
            SendRequest("SELECT TOP 1 * FROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nORDER BY SupplyDate ASC");
        }
        public void ShowAverageQuantityByProductType()
        {
            SendRequest("SELECT ProductTypes.Name AS TypeName, AVG(Products.Quantity) AS AverageQuantity\r\nFROM Products\r\nJOIN ProductTypes ON Products.TypeID = ProductTypes.ID\r\nJOIN Suppliers ON Products.SupplierID = Suppliers.ID\r\nGROUP BY ProductTypes.Name;");
        }


        public void ShowSupplierWithMaxProducts()
        {
            string query = "SELECT TOP 1 s.ID AS SupplierID, s.Name AS SupplierName, SUM(p.Quantity) AS TotalQuantity\r\nFROM Suppliers s\r\nJOIN Products p ON s.ID = p.SupplierID\r\nGROUP BY s.ID, s.Name\r\nORDER BY TotalQuantity DESC;\r\n";
            SendRequest(query);
        }

        public void ShowSupplierWithMinProducts()
        {
            string query = "SELECT TOP 1 s.ID AS SupplierID, s.Name AS SupplierName, SUM(p.Quantity) AS TotalQuantity\r\nFROM Suppliers s\r\nJOIN Products p ON s.ID = p.SupplierID\r\nGROUP BY s.ID, s.Name\r\nORDER BY TotalQuantity ASC;\r\n";
            SendRequest(query);

        }

        public void ShowTypeWithMaxProducts()
        {
            string query = "SELECT TOP 1 pt.ID AS ProductTypeID, pt.Name AS ProductTypeName, SUM(p.Quantity) AS TotalQuantity\r\nFROM ProductTypes pt\r\nJOIN Products p ON pt.ID = p.TypeID\r\nGROUP BY pt.ID, pt.Name\r\nORDER BY TotalQuantity DESC;\r\n";
            SendRequest(query);

        }

        public void ShowTypeWithMinProducts()
        {
            string query = "SELECT TOP 1 pt.ID AS ProductTypeID, pt.Name AS ProductTypeName, SUM(p.Quantity) AS TotalQuantity\r\nFROM ProductTypes pt\r\nJOIN Products p ON pt.ID = p.TypeID\r\nGROUP BY pt.ID, pt.Name\r\nORDER BY TotalQuantity ASC;\r\n";
            SendRequest(query);

        }

        public void ShowProductsByDaysAgo(int daysAgo)
        {
            //string query = "SELECT p.ID AS ProductID, p.Name AS ProductName, p.Quantity, p.Cost, p.SupplyDate\r\nFROM Products p\r\nWHERE DATEDIFF(DAY, p.SupplyDate, GETDATE()) >= @DaysAgo;";

            //string query = "SELECT * FROM Products WHERE DATEDIFF(DAY, SupplyDate, GETDATE()) >= @DaysAgo";

            //SendParameterizedRequest(query, new SqlParameter("@DaysAgo", daysAgo));

            string query = "SELECT * FROM Products WHERE DATEDIFF(DAY, SupplyDate, GETDATE()) >= @DaysAgo";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                command.Parameters.AddWithValue("@DaysAgo", daysAgo);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    formInstance?.SetGridView(dt);
                    reader.Close();
                }
            }

        }
    }
}
