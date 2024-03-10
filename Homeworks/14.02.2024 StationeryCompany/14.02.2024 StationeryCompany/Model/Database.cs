using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._02._2024_StationeryCompany.Model
{
    public class Database
    {
        string? connectionString;
        private SqlConnection connect;
        private SqlCommand command;

        public Database()
        {
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");

            connect = new SqlConnection(connectionString);
            command = new SqlCommand();
        }

        public void Connect()
        {
            try
            {
                connect.Open();
                command.Connection = connect;

                MessageBox.Show("Вы успешно подключились к БД");
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

                MessageBox.Show("Вы успешно отключились от БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при отключении от БД. " + ex.Message);
                return;
            }
        }


        public DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable result = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connect))
                {
                    adapter.Fill(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса. " + ex.Message);
                return null;
            }
        }


        public DataTable ExecuteStoredProcedure(string storedProcedureName, Dictionary<string, object> parameters)
        {
            SqlCommand command = new SqlCommand(storedProcedureName, connect);
            command.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable result = new DataTable();
            adapter.Fill(result);

            return result;
        }


        public DataTable ExecuteStoredProcedure(string storedProcedureName)
        {
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }




        // Для измениния
        public void ExecuteStoredProcedure(string storedProcedureName, string name, string newName)
        {
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            // Добавление параметров процедуры
            //command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name;
            //command.Parameters.Add(new SqlParameter("@NewName", SqlDbType.NVarChar, 50)).Value = newName;
            // Добавление параметров процедуры
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name;
            command.Parameters.Add(new SqlParameter("@NewName", SqlDbType.NVarChar, 50)).Value = newName;

            // Выполнение процедуры без получения данных
            command.ExecuteNonQuery();

            // Очищаем параметры
            command.Parameters.Clear();
        }

        // Для удаления и добавления
        public void ExecuteStoredProcedure(string storedProcedureName, string name)
        {
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name;

            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }









        public void ExecuteNonQuery(string query)
        {
            try
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
