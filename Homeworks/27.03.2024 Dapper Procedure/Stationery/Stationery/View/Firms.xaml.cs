﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dapper;

namespace Stationery
{
    /// <summary>
    /// Interaction logic for Firms.xaml
    /// </summary>
    public partial class Firms : Window
    {
        bool Edit;
        int ID;
        public Firms(bool edit = false, int iD = 0)
        {
            InitializeComponent();
            Edit = edit;
            ID = iD;
            if(Edit) Head.Text = "Edit Firm";
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TitlePr.Text == "")
            {
                MessageBox.Show("Fill the parameters");
                return;
            }
            try
            {
                using (IDbConnection db = new SqlConnection(MainWindow.connectionString))
                {
                    string title = TitlePr.Text;
                    if (Edit)
                    {
                        var dynamicParams = new DynamicParameters();
                        dynamicParams.Add("@Id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        dynamicParams.Add("@Title", TitlePr.Text, dbType: DbType.String, direction: ParameterDirection.Input);
                        int n = db.Execute("UpdateFirms", dynamicParams, commandType: CommandType.StoredProcedure);
                        if (n == 1)
                            MessageBox.Show("Фирма успешно изменен!");
                    }
                    else
                    {
                        var dynamicParams = new DynamicParameters();
                        dynamicParams.Add("@Title", TitlePr.Text, dbType: DbType.String, direction: ParameterDirection.Input);
                        int n = db.Execute("InsertIntoFirms", dynamicParams, commandType: CommandType.StoredProcedure);
                        if (n == 1)
                            MessageBox.Show("Фирма успешно добавлена в таблицу!");
                    }
                }
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
