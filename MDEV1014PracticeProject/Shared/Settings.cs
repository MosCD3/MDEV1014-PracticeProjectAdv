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


        public static string mockUserPassword = "123456";
        public static string mockUsername = "moscd3@gmail.com";
        public static string mockToken = "sdjflaksdjf;asldfasdfasdfasd";

        //Auth used
#if DEBUG
        public AuthType authType = AuthType.Mock;
#else
        public AuthType authType = AuthType.Aws;
#endif

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
