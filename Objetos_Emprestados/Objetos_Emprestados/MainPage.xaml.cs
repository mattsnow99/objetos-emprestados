using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Objetos_Emprestados.Models;
using System.Collections.ObjectModel;
using Objetos_Emprestados.Views;
using Objetos_Emprestados.Services;

namespace Objetos_Emprestados
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ObjetoEmprestado> ObjetosEmprestados;
        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ObjetosEmprestados = GetTodosObjetoEmprestados();
            ObjetoListView.ItemsSource = ObjetosEmprestados;

        }
        public ObservableCollection<ObjetoEmprestado> GetTodosObjetoEmprestados()
        {
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            return new ObservableCollection<ObjetoEmprestado>(dao.GetTodos());
        }



        private void OnObjetoProcurado(object sender, TextChangedEventArgs e)
        {
            string texto = ObjetoSearchBar.Text;
            ObjetoListView.ItemsSource = ObjetosEmprestados.Where(
                x => x.Descricao.ToLowerInvariant().Contains(texto.ToLowerInvariant())
            );
        }

        private void OnObjetoSelecionado(object sender, SelectedItemChangedEventArgs e)
        {
            // var ObjetoEmprestado = e.SelectedItem as ObjetoEmprestado;
            ObjetoEmprestado ObjetoEmprestado = e.SelectedItem as ObjetoEmprestado;
            Navigation.PushAsync(new EditObjetoPage(ObjetoEmprestado));
        }

        private void OnAdcionarObjetoEmprestado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditObjetoPage(null));
        }
    }
}
