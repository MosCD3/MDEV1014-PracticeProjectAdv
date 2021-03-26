using System;
using System.Collections.Generic;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            BindingContext = new WelcomePageVM();
            InitializeComponent();
        }
    }
}
