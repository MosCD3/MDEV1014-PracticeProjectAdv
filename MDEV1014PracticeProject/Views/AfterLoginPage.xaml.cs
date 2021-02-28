using System;
using System.Collections.Generic;
using MDEV1014PracticeProject.Models;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class AfterLoginPage : FlyoutPage
    {
        public AfterLoginPage()
        {
            flyoutPage = new FlyoutMenuPage();
            Flyout = flyoutPage;
            Detail = new NavigationPage(new InternalHomePage());

            flyoutPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            }
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuListItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                flyoutPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
