using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Flurl.Http;
using MDEV1014PracticeProject.Models;
using Newtonsoft.Json;

namespace MDEV1014PracticeProject.Services.Auth
{
    public class AwsAuthService : IAuthService
    {
        public AwsAuthService()
        {
        }

        public async Task<AuthSession> SignInAsync(string username, string password)
        {
            var sentObj = new ServerAuth
            {
                Email = username,
                Password = password,
                Action = "SignIn"
            };

            Debug.WriteLine($"api is:{Settings.Shared.API_AWS_AuthSignin}");

            string res = await Settings.Shared.API_AWS_AuthSignin
            .WithTimeout(20)
            .PostJsonAsync(sentObj)
            .ReceiveString();

            Debug.WriteLine($"AWS_Service> Response from server:{res}");

            return JsonConvert.DeserializeObject<AuthSession>(res);
        }
    }
}
