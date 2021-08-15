using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NBLSystemProject.Pages
{

    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (MessageBox.Show("Saindo do Sistema!", "Atenção!!!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK) {
                this.Close();
            }
        }
    }
}
