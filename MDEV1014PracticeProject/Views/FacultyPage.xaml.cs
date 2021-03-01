using System;
using System.Collections.Generic;
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
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
