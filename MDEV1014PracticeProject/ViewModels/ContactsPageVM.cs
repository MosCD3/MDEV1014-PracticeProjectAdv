using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MDEV1014PracticeProject.Models;

namespace MDEV1014PracticeProject.ViewModels
{
    public class ContactsPageVM: ViewModelBase
    {

        public string Title { get; set; }

        public ObservableCollection<User> _itemslist = new ObservableCollection<User>();
        public ObservableCollection<User> ItemsList
        {
            get { return _itemslist; }
            set { SetProperty(ref _itemslist, value); }
        }


        //public User _SelectedItem;
        //public User SelectedItem
        //{
        //    get { return _SelectedItem; }
        //    set
        //    {


        //        SetProperty(ref _SelectedItem, value);

        //        if (value != null)
        //        {
        //            PlaylistItemSelected(SelectedItem);
        //            SelectedItem = null;
        //        }

        //    }
        //}


        public ContactsPageVM()
        {
            ItemsList = new ObservableCollection<User>();
            ItemsList.Add(new User { name = "Mostafa", email = "mostafa.gamal@georgiancollege.ca", image_url = "icon-thumb1.png" });
            ItemsList.Add(new User { name = "Rob", email = "rob@georgiancollege.ca", image_url = "customer.png" });
        }


        //private void PlaylistItemSelected(User item)
        //{
        //    Debug.WriteLine($"user selected with name:{item.Name}");

        //}
    }
}
