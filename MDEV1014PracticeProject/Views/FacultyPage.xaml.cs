using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class FacultyPage : ContentPage
    {
        public FacultyPage()
        {
            BindingContext = new FacultyPageVM();
            InitializeComponent();
        }

        void collectionList_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (collectionList.SelectedItem == null) return;

            var userObject = (e.CurrentSelection.FirstOrDefault() as Faculty);

            if (userObject != null)
            {

                string current = userObject.Name;

                Debug.WriteLine($"current selected faculty:{current}");

                var newPage = new ContactDetailsPage(new User { name = current });
                //var newPage = new ContactDetailsPage(user: userObject);
                Navigation.PushAsync(newPage);

            }



            collectionList.SelectedItem = null;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
