using NBLSystemProject.pages.db;
using NBLSystemProject.pages.utils;
using NBLSystemProject.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBLSystemProject.pages.View.Usuario
{
    /// <summary>
    /// Interaction logic for UsuarioList.xaml
    /// </summary>
    public partial class UsuarioList : Page
    {
        
        Context context;
        int page = 1;
        int qtdRegistrosPage = 6;

        public UsuarioList()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            atualizarPaginador();

        }

        private void atualizarPaginador()
        {
            context = new Context();
            System.Windows.Data.CollectionViewSource usersDatabase =
              ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersDatabase")));
            context.Usuario.Load();

            //usersDatabase.Source = context.Usuario.Local;

            lbRegistros.Text = "Registros: " + context.Usuario.Count();

            //(entidade, pagina, qtd Registros por pagina)
            usersDatabase.Source = PagingExtensions.Page(context.Usuario.Local, this.page, qtdRegistrosPage);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            while (NavigationService.RemoveBackEntry() != null) ;
            NavigationService.Content = new Dashboard();
        }

        private void btnNovo_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new UsuarioForm();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            page += 1;
            atualizarPaginador();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            page -= 1;
            atualizarPaginador();
        }
    }
}
