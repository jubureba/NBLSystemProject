using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using NBLSystemProject.pages;
using NBLSystemProject.pages.db;
using NBLSystemProject.pages.entity;
using NBLSystemProject.pages.utils;
using NBLSystemProject.pages.View;
using NBLSystemProject.pages.View.Usuario;
using NBLSystemProject.services;

namespace NBLSystemProject.Pages {

    public partial class MainWindow : Window {
        public string nomeUsuario { get; set; }

        public MainWindow() {
            InitializeComponent();
            nomeUsuario = "Usuário Mock";
            HomePage();
            DataContext = this;
        }

        public void HomePage()
        {
            if (load_frame.Content == null) {
                load_frame.Content = new Dashboard();
            }
        }

        /*................................................................................
         Buttons ==========================================================================
        ............................................................................... */

        private void btnCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Saindo do Sistema!", "Atenção!!!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            load_frame.Content = new UsuarioList();
        }

        private void BackToHome(object sender, MouseButtonEventArgs e)
        {
            HomePage();
        }
    }
}
