using App2.Data;
using App2.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        private static PessoaDao data;

        public static PessoaDao Database
        {
            get
            {
                if (data == null)
                {
                    data = new PessoaDao(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return data;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
            //MainPage = new CadastroPessoaPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
