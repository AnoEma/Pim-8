
using App2.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {

        public DetailsPage(Models.Pessoas pessoa)
        {
            InitializeComponent();
            MonstrarDados(pessoa);
        }

        private void MonstrarDados(Pessoas pessoa)
        {
            lbl_Nome.Text = "Nome Completo : " + pessoa.Nome;
            lbl_Cpf.Text = "Numero CPF : " + pessoa.CPF;
            lbl_Telefone.Text = "Telefone : " + pessoa.DDD + pessoa.NumeroTelefone;
            lbl_Logradouro.Text = "Logradouro : " + pessoa.Logradouro;
            lbl_Numero.Text = "Numero : " + pessoa.Numero;
            lbl_Cep.Text = "CEP : " + pessoa.Cep;
            lbl_Bairro.Text = "Bairro : " + pessoa.Bairro;
            lbl_Cidade.Text = "Cidade : " + pessoa.Cidade;
            lbl_Estado.Text = "Estado : " + pessoa.Estado.ToUpper();
        }

        private async void Bbtn_Editar_Pessoa(object sender, System.EventArgs e)
        {
            var cpf = lbl_Cpf.Text.Substring(13, 11);
            await Navigation.PushAsync(new AlterarPage(cpf));
        }

        private async void Btn_Deletar_Pessoa(object sender, System.EventArgs e)
        {
            var cpf = lbl_Cpf.Text.Substring(13, 11);

            if (!string.IsNullOrEmpty(cpf))
            {
                try
                {
                    var pessoa = await App.Database.GetPessoas(cpf);
                    if(pessoa == null)
                    {
                        await DisplayAlert("Erro", "Ocorreu erro poderia refazer o processo", "OK");
                        await Navigation.PushAsync(new MainPage());
                        return;
                    }
                    var result = App.Database.DeletarPessoa(pessoa);

                    if (result == true)
                    {
                        await DisplayAlert("Alerta", "Usuario foi deletado com sucesso", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "O registro não foi deletado com sucesso", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }

            }
        }
    }
}