using System;
namespace MDEV1014PracticeProject
{
    public class Settings
    {


        public string mockUserPassword = "admin";
        public string mockUsername = "admin";


        //API
        public string API_Test = "https://api.github.com/users/petrgazarov";
        public Settings()
        {
        }


        public static Settings Shared = new Settings();
    }
}
