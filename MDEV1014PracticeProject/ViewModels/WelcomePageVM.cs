using System;
using System.Windows.Input;
using MDEV1014PracticeProject.Views;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class WelcomePageVM : ViewModelBase
    {
        public ICommand LoginCommand => new Command(LoginTapped);
        public WelcomePageVM()
        {
            Title = "Welcome";
        }

        private void LoginTapped() {
            MyApp.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
