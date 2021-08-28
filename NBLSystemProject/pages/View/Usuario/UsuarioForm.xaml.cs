using NBLSystemProject.pages.entity;
using NBLSystemProject.services.usuario;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBLSystemProject.pages.View.Usuario
{
    /// <summary>
    /// Interaction logic for UsuarioForm.xaml
    /// </summary>
    public partial class UsuarioForm : Page
    {
        UsuarioService service;
        UsuarioServiceImpl serviceimpl = new UsuarioServiceImpl();
        Funcionario usuario;
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.RemoveBackEntry();
            while (NavigationService.RemoveBackEntry() != null) ;
            NavigationService.Content = new UsuarioList();

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNome != null)
            {
                service = serviceimpl;
                usuario = new Funcionario
                {
                    login = tbUsuario.Text,
                    nome = tbNome.Text,
                    senha = tbSenha.Text
                };

                service.Insert(usuario);

            }
        }
    }
}
