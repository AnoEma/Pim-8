
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
            var pessoa = new Pessoas
            {
                Nome = lbl_Nome.Text,
                CPF = lbl_Cpf.Text,
                Logradouro = lbl_Logradouro.Text,
                Numero = int.Parse(lbl_Numero.Text),
                Cep = int.Parse(lbl_Cep.Text),
                Bairro = lbl_Bairro.Text,
                Cidade = lbl_Cidade.Text,
                Estado = lbl_Estado.Text,

            };
            await Navigation.PushAsync(new AlterarPage(pessoa));
        }

        private async void Btn_Deletar_Pessoa(object sender, System.EventArgs e)
        {
            var cpf = lbl_Cpf.Text;

            if (!string.IsNullOrEmpty(cpf))
            {
                try
                {
                    var result = App.Database.DeletarPessoa(cpf);

                    if (result == true)
                    {
                        await DisplayAlert("Alerta", "Usuario foi deletado com sucesso", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }

                    await DisplayAlert("Alerta", "O registro não foi deletado com sucesso", "OK");

                }
                catch (Exception ex )
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
                
            }
        }
    }
}