using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class DatabaseManager
{
    private string connectionString;
    public DataSet dataSet;
    private SqlDataAdapter productTypesAdapter, suppliersAdapter, productsAdapter;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
        Initialize();
    }

    public void Initialize()
    {
        // Инициализация адаптеров и DataSet
        productsAdapter = new SqlDataAdapter("SELECT * FROM Products", connectionString);
        productTypesAdapter = new SqlDataAdapter("SELECT * FROM ProductTypes", connectionString);
        suppliersAdapter = new SqlDataAdapter("SELECT * FROM Suppliers", connectionString);

        SqlCommandBuilder productsCommandBuilder = new SqlCommandBuilder(productsAdapter);
        SqlCommandBuilder productTypesCommandBuilder = new SqlCommandBuilder(productTypesAdapter);
        SqlCommandBuilder suppliersCommandBuilder = new SqlCommandBuilder(suppliersAdapter);

        dataSet = new DataSet();
        productsAdapter.Fill(dataSet, "Products");
        productTypesAdapter.Fill(dataSet, "ProductTypes");
        suppliersAdapter.Fill(dataSet, "Suppliers");

        // Устанавливаем отношения между таблицами
        DataRelation typeRelation = new DataRelation("TypeRelation", dataSet.Tables["ProductTypes"].Columns["ID"], dataSet.Tables["Products"].Columns["TypeID"]);
        DataRelation supplierRelation = new DataRelation("SupplierRelation", dataSet.Tables["Suppliers"].Columns["ID"], dataSet.Tables["Products"].Columns["SupplierID"]);

        dataSet.Relations.Add(typeRelation);
        dataSet.Relations.Add(supplierRelation);
    }

    public void UpdateDataSource()
    {
        // Обновление источника данных
        productTypesAdapter.Update(dataSet, "ProductTypes");
        suppliersAdapter.Update(dataSet, "Suppliers");
        productsAdapter.Update(dataSet, "Products");
    }
    public void LoadDatabaseFromSource()
    {
        // Загрузка актуальной версии БД из источника
        dataSet.Clear();
        productTypesAdapter.Fill(dataSet, "ProductTypes");
        suppliersAdapter.Fill(dataSet, "Suppliers");
        productsAdapter.Fill(dataSet, "Products");
    }

    

    public DataTable GetProductTypesDataTable()
    {
        try
        {
            return dataSet.Tables["ProductTypes"];
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetSuppliersDataTable()
    {
        try
        {
            return dataSet.Tables["Suppliers"];
        }
        catch
        {
            throw;
        }

    }

    public DataTable GetProductsDataTable()
    {
        try
        {
            return dataSet.Tables["Products"];
        }
        catch
        {
            throw;
        }
    }





    public void AddSupllier(string newName)
    {
        try
        {
            // Логика добавления поставщика
            DataRow newRow = dataSet.Tables["Suppliers"].NewRow();

            newRow["Name"] = newName;

            dataSet.Tables["Suppliers"].Rows.Add(newRow);
            Console.WriteLine("Поставщик добавлен успешно.");
        }
        catch 
        {
            throw;
        }
    }

    public void AddProductType(string newName)
    {
        try
        {
            DataRow newRow = dataSet.Tables["ProductTypes"].NewRow();

            Console.WriteLine("Введите имя типа продукта:");
            newRow["Name"] = Console.ReadLine();

            dataSet.Tables["ProductTypes"].Rows.Add(newRow);
        }
        catch
        {
            throw;
        }
    }




    public void UpdateSupplierByName(string currentName, string newName)
    {
        DataRow[] rows = dataSet.Tables["Suppliers"].Select($"Name = '{currentName}'");

        if (rows.Length > 0)
        {
            foreach (DataRow row in rows)
            {
                row["Name"] = newName;
            }

            MessageBox.Show($"Поставщик с именем '{currentName}' успешно обновлен на '{newName}'.");
        }
        else
        {
            MessageBox.Show($"Поставщик с именем '{currentName}' не найден.");
        }
    }

    public void UpdateProductTypeByName(string currentName, string newName)
    {
        DataRow[] rows = dataSet.Tables["ProductTypes"].Select($"Name = '{currentName}'");

        if (rows.Length > 0)
        {
            foreach (DataRow row in rows)
            {
                row["Name"] = newName;
            }

            MessageBox.Show($"Тип продукта с именем '{currentName}' успешно обновлен на '{newName}'.");
        }
        else
        {
            MessageBox.Show($"Тип продукта с именем '{currentName}' не найден.");
        }
    }







    public void DeleteProductTypeByName(string typeName)
    {
        DataRow[] rows = dataSet.Tables["ProductTypes"].Select($"Name = '{typeName}'");

        if (rows.Length > 0)
        {
            foreach (DataRow row in rows)
            {
                row.Delete();
            }

            MessageBox.Show($"Тип продукта с именем '{typeName}' успешно удален.");
        }
        else
        {
            MessageBox.Show($"Тип продукта с именем '{typeName}' не найден.");
        }
    }

    public void DeleteSupplierByName(string supplierName)
    {
        DataRow[] rows = dataSet.Tables["Suppliers"].Select($"Name = '{supplierName}'");

        if (rows.Length > 0)
        {
            foreach (DataRow row in rows)
            {
                row.Delete();
            }

            MessageBox.Show($"Поставщик с именем '{supplierName}' успешно удален.");
        }
        else
        {
            MessageBox.Show($"Поставщик с именем '{supplierName}' не найден.");
        }
    }





    public void AddProduct(string name, string type, string supplier, decimal quantity, decimal cost, DateTime supplyDate)
    {
        // Создание новой строки в таблице Products
        DataRow newRow = dataSet.Tables["Products"].NewRow();

        // Заполнение новой строки данными из элементов формы
        newRow["Name"] = name;
        newRow["TypeID"] = GetProductTypeId(type); // Метод GetProductTypeId будет ниже
        newRow["SupplierID"] = GetSupplierId(supplier); // Метод GetSupplierId будет ниже
        newRow["Quantity"] = quantity;
        newRow["Cost"] = cost;
        newRow["SupplyDate"] = supplyDate;

        // Добавление новой строки в таблицу Products
        dataSet.Tables["Products"].Rows.Add(newRow);

        // Обновление источника данных
        UpdateDataSource();

        Console.WriteLine("Продукт успешно добавлен.");
    }

    public void UpdateProduct(string name, string newName, string type, string supplier, decimal quantity, decimal cost, DateTime supplyDate)
    {
        // Находим соответствующую строку в таблице Products
        DataRow[] rows = dataSet.Tables["Products"].Select($"Name = '{name}'");

        if (rows.Length > 0)
        {
            DataRow selectedProduct = rows[0];

            // Обновление данных в выбранной строке из элементов формы
            selectedProduct["Name"] = newName;
            selectedProduct["TypeID"] = GetProductTypeId(type);
            selectedProduct["SupplierID"] = GetSupplierId(supplier);
            selectedProduct["Quantity"] = quantity;
            selectedProduct["Cost"] = cost;
            selectedProduct["SupplyDate"] = supplyDate;

            // Обновление источника данных
            UpdateDataSource();

            Console.WriteLine("Продукт успешно изменен.");
        }
        else
        {
            Console.WriteLine($"Продукт с именем '{name}' не найден.");
        }
    }

    public void DeleteProduct(string name)
    {
        // Находим соответствующую строку в таблице Products
        DataRow[] rows = dataSet.Tables["Products"].Select($"Name = '{name}'");

        if (rows.Length > 0)
        {
            // Удаление выбранной строки из таблицы Products
            rows[0].Delete();

            // Обновление источника данных
            UpdateDataSource();

            Console.WriteLine("Продукт успешно удален.");
        }
        else
        {
            Console.WriteLine($"Продукт с именем '{name}' не найден.");
        }
    }

    // Метод для получения ID типа продукта по его имени
    private int GetProductTypeId(string typeName)
    {
        DataRow[] rows = dataSet.Tables["ProductTypes"].Select($"Name = '{typeName}'");

        if (rows.Length > 0)
        {
            return Convert.ToInt32(rows[0]["ID"]);
        }
        else
        {
            // Если тип продукта не найден, может быть нужно обработать эту ситуацию соответствующим образом
            return -1; // или другое значение по умолчанию
        }
    }

    // Метод для получения ID поставщика по его имени
    private int GetSupplierId(string supplierName)
    {
        DataRow[] rows = dataSet.Tables["Suppliers"].Select($"Name = '{supplierName}'");

        if (rows.Length > 0)
        {
            return Convert.ToInt32(rows[0]["ID"]);
        }
        else
        {
            // Если поставщик не найден, может быть нужно обработать эту ситуацию соответствующим образом
            return -1; // или другое значение по умолчанию
        }
    }
}
