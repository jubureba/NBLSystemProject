using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NBLSystemProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string connectionString =
        @"Data Source=JUBUREBA-PC\MSSQLSERVER01;Initial Catalog=NBLSystem;Integrated Security=True";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
