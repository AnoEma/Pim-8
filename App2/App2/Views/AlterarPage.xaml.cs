using App2.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarPage : ContentPage
    {
        public AlterarPage(Models.Pessoas pessoa)
        {
            InitializeComponent();
            MonstrarPessoa(pessoa);
        }

        private void MonstrarPessoa(Pessoas pessoa)
        {
            lbl_Nome.Text = "Nome Completo : " + pessoa.Nome;
            lbl_Telefone.Text = "Telefone : " + pessoa.DDD + pessoa.NumeroTelefone;
            lbl_Logradouro.Text = "Logradouro : " + pessoa.Logradouro;
            lbl_Numero.Text = "Numero : " + pessoa.Numero;
            lbl_Cep.Text = "CEP : " + pessoa.Cep;
            lbl_Bairro.Text = "Bairro : " + pessoa.Bairro;
            lbl_Cidade.Text = "Cidade : " + pessoa.Cidade;
            lbl_Estado.Text = "Estado : " + pessoa.Estado.ToUpper();
        }

        private async void Btn_Editar_Pessoa(object sender, EventArgs e)
        {
            var pessoa = new Pessoas
            {
                Nome = lbl_Nome.Text,
                Logradouro = lbl_Logradouro.Text,
                Numero = int.Parse(lbl_Numero.Text),
                Cep = int.Parse(lbl_Cep.Text),
                Bairro = lbl_Bairro.Text,
                Cidade = lbl_Cidade.Text,
                Estado = lbl_Estado.Text,
            };

            if(pessoa != null)
            {
                try
                {
                    var result = App.Database.SalvarPessoa(pessoa);

                    if (result == true)
                    {
                        await DisplayAlert("Alert", "Dados atualizado com sucesso!", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    await DisplayAlert("Alert", "Dados não atualizado com sucesso!", "OK");
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Erro", "Ocorreu erro ao atualizar dados!", "OK");
                }

            }
        }

        private async void Btn_Voltar_PR(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}