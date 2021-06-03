using System;
using System.Threading.Tasks;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();
        void LogoutUserAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Page GetPage<TViewModel>() where TViewModel : ViewModelBase;
        Page GetCurrentPage();
        Task PopLastAsync();
    }
}
