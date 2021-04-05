using System;
using MDEV1014PracticeProject.Services.Auth;

namespace MDEV1014PracticeProject
{
    public class Adapter
    {
        public Adapter()
        {
        }


        public IAuthService authService {
            get {
                switch (Settings.Shared.authType) {
                    case AuthType.ServerBased:
                        return new AuthService();
                    case AuthType.Aws:
                        return new AwsAuthService();
                    case AuthType.Mock:
                        return new FakeAuthService();
                }

                return new AuthService();

            }

        }

        public static Adapter Shared = new Adapter();
    }
}
