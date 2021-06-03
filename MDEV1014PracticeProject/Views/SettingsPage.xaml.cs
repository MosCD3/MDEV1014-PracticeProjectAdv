using System;
using System.Collections.Generic;
using MDEV1014PracticeProject.Services.Auth;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            BindingContext = new SettingsPageVM(Locator.Instance.Resolve<IAuthService>());
            InitializeComponent();
        }
    }
}
