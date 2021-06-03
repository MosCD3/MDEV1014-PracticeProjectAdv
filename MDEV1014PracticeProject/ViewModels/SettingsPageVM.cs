using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MDEV1014PracticeProject.Services.Auth;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class SettingsPageVM : ViewModelBase
    {
        public ICommand SignoutCommand { get; set; }
        private IAuthService authService;
        private string _UserEmail;
        public string UserEmail
        {
            get { return _UserEmail; }
            set { SetProperty(ref _UserEmail, value); }
        }

        public SettingsPageVM(IAuthService auth)
        {
            authService = auth;
            Title = "Settings";
            SignoutCommand = new Command(()=> {
                OnSignOutAsync();
            });

            PopultaeData();
        }

        private void PopultaeData() {
            UserEmail = authService?.activeUser?.email;
        }


        private async Task OnSignOutAsync() {
            var response = await MyApp.MainPage.DisplayAlert("Attention", "Sign out?", "Sign Out", "Cancel");
            if(response)
                await MyApp.SignOutAsync();

        }

    }
}
