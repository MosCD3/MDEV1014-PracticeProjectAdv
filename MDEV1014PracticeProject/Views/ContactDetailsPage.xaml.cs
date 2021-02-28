using System;
using System.Collections.Generic;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(User user)
        {
            BindingContext = new ContactDetailsPageVM(user: user);
            InitializeComponent();
        }
    }
}
