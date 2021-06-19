using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.Views;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class FlyoutMenuPageVM: ViewModelBase
    {
        public ObservableCollection<MenuListItem> _itemslist = new ObservableCollection<MenuListItem>();
        public ObservableCollection<MenuListItem> ItemsList
        {
            get { return _itemslist; }
            set { SetProperty(ref _itemslist, value); }
        }


        public MenuListItem _SelectedItem;
        public MenuListItem SelectedItem
        {
            get { return _SelectedItem; }
            set
            {


                SetProperty(ref _SelectedItem, value);

                if (value != null)
                {
                    PlaylistItemSelected(SelectedItem);
                    SelectedItem = null;
                }

            }
        }

        public FlyoutMenuPageVM()
        {
            var items = new ObservableCollection<MenuListItem>()
            {
                new MenuListItem { Title = "Home" , IconSource = "home.png" },
                new MenuListItem { Title = "Contacts" , IconSource = "contacts.png" },
                new MenuListItem { Title = "Faculty" , IconSource = "contacts.png" },
                new MenuListItem { Title = "Settings" , IconSource = "contacts.png" },
            };

            ItemsList = items;
        }


        void PlaylistItemSelected(MenuListItem item) {
            Debug.WriteLine($"Please navigate to:{item.Title}");

            NavMenu nav = NavMenu.Home;

            switch (item.Title) {
                case "Home":
                    nav = NavMenu.Home;
                    break;
                case "Contacts":
                    nav = NavMenu.Contacts;
                    break;
                case "Faculty":
                    nav = NavMenu.Faculty;
                    break;
                case "Settings":
                    nav = NavMenu.Settings;
                    break;

            }
            MessagingCenter.Send<object, NavMenu>(this, Settings.MESSENGERKEY_MAINNAV, nav);
        }
    }
}
