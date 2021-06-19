using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MDEV1014PracticeProject.Models;
using MDEV1014PracticeProject.Services.Navigation;

namespace MDEV1014PracticeProject.ViewModels
{
    public class ContactDetailsPageVM : ViewModelBase
    {
        private User userModel;



        public string _cName;
        public string cName
        {
            get { return _cName; }
            set { SetProperty(ref _cName, value); }
        }


        public string _cEmail;
        public string cEmail
        {
            get { return _cEmail; }
            set { SetProperty(ref _cEmail, value); }
        }

        public string _cCollege;
        public string cCollege
        {
            get { return _cCollege; }
            set { SetProperty(ref _cCollege, value); }
        }

        private INavigationService navigationService;
        public ContactDetailsPageVM(INavigationService nav)
        {
            navigationService = nav;

        }

        private void PopulateData(User user) {
            userModel = user;
            cName = userModel.name;
            cEmail = userModel.email;
            cCollege = "Georgian College";
        }


        public override Task InitializeAsync(object navigationData)
        {
            var castedUser = navigationData as Faculty;
            if (castedUser == null) {
                Debug.WriteLine("Errorr>ContactDetailsPageVM> InitializeAsync> Casting Faculty failed");
                return null;
            }
            PopulateData(castedUser);
            return base.InitializeAsync(navigationData);
        }
    }
}
