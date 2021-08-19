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
using NBLSystemProject.pages.db;
using NBLSystemProject.pages.entity;
using NBLSystemProject.pages.utils;
using NBLSystemProject.services;

namespace NBLSystemProject.Pages {

    public partial class Index : Window {

        List<GanhosPotenciais> ganhosPotenciais = new List<GanhosPotenciais>();
        Context context;
        Mensagem mensagem;

        MensagemServiceImpl serviceimpl = new MensagemServiceImpl();
        MensagemService service;
        public PieChart PieChart { get; set; } 
        public SeriesCollection SeriesCollection { get; set; }

        Mensagem MensagemSelecionada { get; set; }

        public Index() {
            InitializeComponent();

            ganhosPotenciais.Add(new GanhosPotenciais() { id = 1, titulos = "Produto01", valores = new ChartValues<double> { 10, 1 } });
            ganhosPotenciais.Add(new GanhosPotenciais() { id = 2, titulos = "Produto02",  valores = new ChartValues<double> { 50, 20 } });
            ganhosPotenciais.Add(new GanhosPotenciais() { id = 3, titulos = "Produto03", valores = new ChartValues<double> { 80, 8 } });
            ganhosPotenciais.Add(new GanhosPotenciais() { id = 4, titulos = "Produto04", valores = new ChartValues<double> { 60, 16 } });

            foreach (GanhosPotenciais g in ganhosPotenciais) {
                preencherGrafico();
            }
            preencherGrafico2(); 
            getMensagens();

            DataContext = this;
        }

        private void preencherGrafico() {
            SeriesCollection = new SeriesCollection{
               // new ColumnSeries { Title = "TITULO1",Values = new ChartValues<double> { 33, 10, 55, 11, 68 }}
            };
            
            for(int x=0; x < ganhosPotenciais.Count; x++) { 
                SeriesCollection.Add(new ColumnSeries {
                    Title =  ganhosPotenciais[x].titulos ,
                    Values = ganhosPotenciais[x].valores
                });
            }

        }

        private void preencherGrafico2()
        {
            piechart1.Series = new SeriesCollection
            {

            };
            piechart1.Series.Add(new PieSeries { Title = "Contas à Pagar",  StrokeThickness = 0, Values = new ChartValues<double> { 15234.00 } });
            piechart1.Series.Add(new PieSeries { Title = "Contas à Receber",  StrokeThickness = 0, Values = new ChartValues<double> { 12595.55 } });
            piechart1.Series.Add(new PieSeries { Title = "Vendas",  StrokeThickness = 0, Values = new ChartValues<double> { 19865.00 } });
            piechart1.Series.Add(new PieSeries { Title = "Despesas", StrokeThickness = 0, Values = new ChartValues<double> { 9120.00 } });
        }

        private void btnCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (MessageBox.Show("Saindo do Sistema!", "Atenção!!!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK) {
                this.Close();
            }
        }


        private void limparCampos()
        {
            tbMensagem.Text = null;
        }

        public void getMensagens()
        {
            using (var context = new Context())
            {
                var msg = context.Mensagem.ToList();
                //msg.ForEach(i => MessageBox.Show("" + i));
                System.Windows.Data.CollectionViewSource categoryViewSource =
                ((CollectionViewSource)(this.FindResource("categoryViewSource")));
                categoryViewSource.Source = msg;
            }
            mensagemItens.SelectedIndex = mensagemItens.Items.Count - 1;
            mensagemItens.ScrollIntoView(mensagemItens.SelectedItem);
        }


        /*................................................................................
         Buttons ==========================================================================
        ..................................................................................
         */

        private void iconClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            myPopup.IsOpen = true;
        }

        private void ImageAwesome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tbMensagem != null)
            {
                service = serviceimpl;
                mensagem = new Mensagem();

                mensagem.mensagem = tbMensagem.Text;
                service.Insert(mensagem);

                limparCampos();
                getMensagens();
            }
        }

        private void popupClose(object sender, RoutedEventArgs e)
        {
            if(myPopup.IsOpen)
            {
                myPopup.IsOpen = false;
            }
        }

        private void saveMensagem(object sender, RoutedEventArgs e)
        {
            var selectedItem = mensagemItens.SelectedItem as Mensagem;
            var selectedId = selectedItem.id;

            service = serviceimpl;
            service.Delete(selectedId);

            getMensagens();

            if (myPopup.IsOpen)
            {
                myPopup.IsOpen = false;
            }
        }

        private void mensagemItens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                myPopup.IsOpen = false;
            }
        }
    }
}
