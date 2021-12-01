using App2.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarPage : ContentPage
    {
        public AlterarPage(string cpf)
        {
            InitializeComponent();
            MonstrarPessoa(cpf);
        }

        private async void MonstrarPessoa(string cpf)
        {
            var pessoa = await App.Database.GetPessoas(cpf);

            Entry_CPF.Text = pessoa.CPF;
            Entry_Nome.Text = pessoa.Nome;
            Entry_Telefone.Text =  pessoa.DDD + pessoa.NumeroTelefone;
            Entry_Logradouro.Text = pessoa.Logradouro;
            Entry_Numero.Text = pessoa.Numero.ToString();
            Entry_Cep.Text = pessoa.Cep;
            Entry_Bairro.Text = pessoa.Bairro;
            Entry_Cidade.Text = pessoa.Cidade;
            Entry_Estado.Text = pessoa.Estado;
        }

        private async void Btn_Editar_Pessoa(object sender, EventArgs e)
        {
            var pessoa = new Pessoas
            {
                CPF = Entry_CPF.Text,
                Nome = Entry_Nome.Text,
                DDD = Entry_Telefone.Text?.Substring(0, 2),
                NumeroTelefone = Entry_Telefone.Text?.Substring(2, 9),
                Logradouro = Entry_Logradouro.Text,
                Numero = int.Parse(Entry_Numero.Text),
                Cep = Entry_Cep.Text,
                Bairro = Entry_Bairro.Text,
                Cidade = Entry_Cidade.Text,
                Estado = Entry_Estado.Text.ToUpper(),
                Ativo = true,
                Telefones = TipoTelefone.Celular
            };

            if (pessoa != null)
            {
                try
                {
                    var result = App.Database.SalvarPessoa(pessoa);

                    if (result == true)
                    {
                        await DisplayAlert("Alert", "Dados atualizado com sucesso!", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Dados não atualizado com sucesso!", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }

        private async void Btn_Voltar_PR(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}