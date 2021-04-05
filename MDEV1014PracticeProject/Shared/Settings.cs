using System;
namespace MDEV1014PracticeProject
{
    public enum AuthType {
        ServerBased,
        Aws,
        Mock
    }
    public class Settings
    {


        public static string mockUserPassword = "moscd3@gmail.com";
        public static string mockUsername = "123456";
        public static string mockToken = "sdjflaksdjf;asldfasdfasdfasd";

        //Auth used
        public AuthType authType = AuthType.Aws;

        //API
        public string API_Test = "https://api.github.com/users/petrgazarov";
        public string API_AWS_AuthSignin
        {
            get => Constants.API_AWS_Base + "/dev/auth";
        }

        public Settings()
        {
        }


        public static Settings Shared = new Settings();
    }
}
