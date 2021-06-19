using System;
using System.Collections.Generic;
using System.Diagnostics;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.ViewModels;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Views
{
    public partial class AfterLoginPage : FlyoutPage
    {
        public AfterLoginPage()
        {
            //flyoutPage = new FlyoutMenuPage();
            //Flyout = flyoutPage;
            //Detail = new NavigationPage(new InternalHomePage());

            //flyoutPage.listView.ItemSelected += OnItemSelected;

            //if (Device.RuntimePlatform == Device.UWP)
            //{
            //    FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            //}
            var page = new FlyoutMenuPage();
            page.BindingContext = Locator.Instance.Resolve<FlyoutMenuPageVM>();
            
            Flyout = page;


            var details = new NavigationPage(new InternalHomePage());
            details.BindingContext = Locator.Instance.Resolve<InternalHomePageVM>();
            Detail = details;

            MessagingCenter.Subscribe<object, NavMenu>(this, Settings.MESSENGERKEY_MAINNAV, OnNavigateRecieved);

            InitializeComponent();
        }


        //void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MenuListItem;
        //    if (item != null)
        //    {
        //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        //        //Padding.listView.SelectedItem = null;
        //        IsPresented = false;
        //    }
        //}

        public void OnNavigateRecieved(object sender, NavMenu msg)
        {
            ContentPage page = null;

            switch (msg)
            {
                case NavMenu.Home:
                    page = new InternalHomePage();
                    page.BindingContext = Locator.Instance.Resolve<InternalHomePageVM>();
                    
                    break;

                case NavMenu.Contacts:
                    page = new ContactsPage();
                    page.BindingContext = Locator.Instance.Resolve<ContactsPageVM>();
                    break;

                case NavMenu.Faculty:
                    page = new FacultyPage();
                    page.BindingContext = Locator.Instance.Resolve<FacultyPageVM>();
                    break;

                case NavMenu.Settings:
                    page = new SettingsPage();
                    page.BindingContext = Locator.Instance.Resolve<SettingsPageVM>();
                    break;

                

                default:
                    Debug.WriteLine($"Error: cannot find nav key for:{msg.ToString()}");
                    return;
            }

            if (page != null)
            {
                Detail = new NavigationPage(page);
                IsPresented = false;
            }


        }
    }
}
