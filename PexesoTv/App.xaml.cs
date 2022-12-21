using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PexesoTv.Views;
using System.ComponentModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PexesoTv
{
    public partial class App : Application
    {
        private static IContainer _container;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
