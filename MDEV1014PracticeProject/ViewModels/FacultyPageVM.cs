using System;
using System.Diagnostics;
using System.Windows.Input;
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

        public ICommand ChangeTitleCommand { get; set; }

        public FacultyPageVM()
        {
            PageTitle = "Faculty List";
            ChangeTitleCommand = new Command(() =>
            {
                Console.WriteLine("inotify method");
                PageTitle = "Menu Items";
            });

        }

        void ChangeTitleAction() {
        }

        void LoadFacultyAsync() {
            //3 sec feh API
            //FacultyList = "sdfjskdf"
        }
    }
}
