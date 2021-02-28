using System;
using MDEV1014PracticeProject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDEV1014PracticeProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AfterLoginPage();
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
