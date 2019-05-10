using Objetos_Emprestados.Models;
using Objetos_Emprestados.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Objetos_Emprestados.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditObjetoPage : ContentPage
	{
        private ObjetoEmprestado objetoEmprestado;
		public EditObjetoPage (ObjetoEmprestado objetos_Emprestados)
		{
			InitializeComponent ();

            if (objetos_Emprestados != null) // Editar / Excluir
            {
                this.objetoEmprestado = objetos_Emprestados;
                DescricaoEntry.Text = objetos_Emprestados.Descricao;
                NomeEntry.Text = objetos_Emprestados.Nome;
                DataDatePicker.Date = objetos_Emprestados.Data;
                Title = "Editar objeto emprestado";
                SalvarButton.IsVisible = false;
                AtualizarButton.IsVisible = true;
                ExcluirButton.IsVisible = true;
            }
            else // novo
            {
                DataDatePicker.Date = DateTime.Now;
                Title = "Novo objeto emprestado";
            }
        }

        private void OnSalvar(object sender, EventArgs e)
        {
            // Criar o objeto (pegar informações na tela)
            ObjetoEmprestado objeto = new ObjetoEmprestado();
            objeto.Descricao = DescricaoEntry.Text;
            objeto.Nome = NomeEntry.Text;
            objeto.Data = DataDatePicker.Date;

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Inserir(objeto);

            Navigation.PopAsync();
        }

        private void OnAtualizar(object sender, EventArgs e)
        {
            // Atualizar as informações
            objetoEmprestado.Descricao = DescricaoEntry.Text;
            objetoEmprestado.Nome = NomeEntry.Text;
            objetoEmprestado.Data = DataDatePicker.Date;

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Atualizar(objetoEmprestado);

            Navigation.PopAsync();
        }

        private void OnExcluir(object sender, EventArgs e)
        {
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.ExcluirPorId(objetoEmprestado.Id);

            Navigation.PopAsync();
        }
    }
}