using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.Services.Navigation;
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

        public Faculty _SelectedItem;
        public Faculty SelectedItem
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

        public ICommand ChangeTitleCommand { get; set; }

        public FacultyPageVM()
        {
            PageTitle = "Faculty List";
            ChangeTitleCommand = new Command(() =>
            {
                PageTitle = "Menu Items";
            });
        }

        void  LoadFacultyAsync() {
            //3 sec feh API
            //Load faculty information from API
            var itemsResult = new ObservableCollection<Faculty>();
            itemsResult.Add(new Faculty { name = "Moos", Department = "IT", email = "moos@college.ca" , image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Jessics", Department = "IT", email = "jess@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Mark", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "David", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Anyname", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            itemsResult.Add(new Faculty { name = "Rob", Department = "IT", email = "rob@college.ca", image_url = "customer.png" });
            //loading from server too 3 sec
            Task.Delay(3000);
            ItemsList = itemsResult;

        }


        private async Task PlaylistItemSelected(Faculty item)
        {
            if (item == null)
            {
                Debug.WriteLine("Error user casting null");
                return;
            }

            var navService = Locator.Instance.Resolve<INavigationService>();
            navService.NavigateToAsync<ContactDetailsPageVM>(item);

            //Debug.WriteLine($"Please edit CPE:{cpe.name}");

            //var navigationParameter = new Dictionary<string, object>
            //    {
            //        { "location", cpe },
            //        { "handler", SuccessHandler }
            //    };

            //await NavigationService.NavigateToAsync<CpeAddEditVM>(navigationParameter);

        }

        public override Task InitializeAsync(object navigationData)
        {

            LoadFacultyAsync();
            return base.InitializeAsync(navigationData);
        }
    }
}
