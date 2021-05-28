using System;
using System.Collections.Generic;
using MDEV1014PracticeProject.Services.Auth;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {

            var a = Locator.Instance.Resolve<IAuthService>();
            BindingContext = new LoginVM(a);
            InitializeComponent();
        }
    }
}
