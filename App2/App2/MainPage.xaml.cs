using App2.Data;
using App2.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Btn_Consulta_CPF(object sender, EventArgs e)
        {
            var cpf = Entry_CPF.Text;
            if (!string.IsNullOrEmpty(cpf))
            {
                try
                {
                    var pessoa = await App.Database.GetPessoas(cpf);

                    if (pessoa != null)
                    {
                        await Navigation.PushAsync(new DetailsPage(pessoa));
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Usuario não encontrado!", "OK");
                    }
                    
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
              
            }
            else
            {
                await DisplayAlert("Alerta", "Informa o CPF!", "OK");
            }
        }


        private async void Btn_Cadatro_Pessoa(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPessoaPage());
        }
    }
}
