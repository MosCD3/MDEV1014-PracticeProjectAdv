using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MDEV1014PracticeProject.Models;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class FacultyPageVM : ViewModelBase
    {
        

        public string _PageTitle;
        public string PageTitle
        {
            get { return _PageTitle; }
            set { SetProperty(ref _PageTitle, value); }
        }

        public ObservableCollection<Faculty> _itemslist = new ObservableCollection<Faculty>();
        public ObservableCollection<Faculty> ItemsList
        {
            get { return _itemslist; }
            set { SetProperty(ref _itemslist, value); }
        }

        public ICommand ChangeTitleCommand { get; set; }

        public FacultyPageVM()
        {
            PageTitle = "Faculty List";
            ChangeTitleCommand = new Command(() =>
            {
                PageTitle = "Menu Items";
            });

            LoadFacultyAsync();

        }

        void ChangeTitleAction() {
        }

        void  LoadFacultyAsync() {
            //3 sec feh API
            //Load faculty information from API
            var itemsResult = new ObservableCollection<Faculty>();
            itemsResult.Add(new Faculty { Name = "Moos", Department = "IT", Email = "moos@college.ca" , AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Jessics", Department = "IT", Email = "jess@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Mark", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "David", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Anyname", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            itemsResult.Add(new Faculty { Name = "Rob", Department = "IT", Email = "rob@college.ca", AvatarUrl = "customer.png" });
            //loading from server too 3 sec
            Task.Delay(3000);
            ItemsList = itemsResult;

        }
    }
}
