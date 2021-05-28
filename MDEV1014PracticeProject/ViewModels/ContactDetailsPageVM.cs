using System;
using MDEV1014PracticeProject.Models;

namespace MDEV1014PracticeProject.ViewModels
{
    public class ContactDetailsPageVM : ViewModelBase
    {
        private User userModel;

        public string cName { get; set; }
        public string cEmail { get; set; }
        public string cCollege { get; set; }

        public ContactDetailsPageVM(User user)
        {
            userModel = user;
            cName = userModel.name;
            cEmail = userModel.email;
            cCollege = "Georgian College";

        }
    }
}
