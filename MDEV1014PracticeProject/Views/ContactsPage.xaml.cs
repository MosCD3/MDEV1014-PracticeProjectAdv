using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            BindingContext = new ContactsPageVM();
            InitializeComponent();
            Debug.WriteLine("Am initialized");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("Am Contacts appearing");
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (collectionList.SelectedItem == null) return;

            var userObject = (e.CurrentSelection.FirstOrDefault() as User);

            if (userObject != null) {

                string current = userObject.name;

                Debug.WriteLine($"current selected item:{current}");

                var newPage = new ContactDetailsPage(user: userObject);
                Navigation.PushAsync(newPage);

            }

           

            collectionList.SelectedItem = null;
        }

    }
}
