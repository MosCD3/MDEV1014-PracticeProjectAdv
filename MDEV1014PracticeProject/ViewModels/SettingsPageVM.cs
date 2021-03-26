using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class SettingsPageVM : ViewModelBase
    {
        public ICommand SignoutCommand { get; set; }
        public SettingsPageVM()
        {
            Title = "Settings";
            SignoutCommand = new Command(()=> {
                OnSignOutAsync();
            });
        }


        private async Task OnSignOutAsync() {
            var response = await MyApp.MainPage.DisplayAlert("Attention", "Sign out?", "Sign Out", "Cancel");
            if(response)
                await MyApp.SignOutAsync();

        }

    }
}
