using App2.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPessoaPage : ContentPage
    {
        public CadastroPessoaPage()
        {
            InitializeComponent();
        }

        private async void Btn_Volta_Inicio(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Btn_Salvar_Pessoa(object sender, EventArgs e)
        {
            Pessoas pessoas = new Pessoas
            {
                Nome = Entry_Nome.Text,
                CPF = Entry_CPF.Text,
                DDD = Entry_DDD.Text,
                NumeroTelefone = Entry_Telefone.Text,
                Logradouro = Entry_Logradouro.Text,
                Numero = int.Parse(Entry_Numero.Text),
                Cep = int.Parse(Entry_Cep.Text),
                Bairro = Entry_Bairro.Text,
                Cidade = Entry_Cidade.Text,
                Estado = Entry_Estado.Text,
            };

            try
            {
                var result = App.Database.SalvarPessoa(pessoas);

                if (result == true)
                {
                    await Navigation.PopToRootAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}