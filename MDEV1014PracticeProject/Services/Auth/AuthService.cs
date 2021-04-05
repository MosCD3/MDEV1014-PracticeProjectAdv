using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Flurl.Http;
using MDEV1014PracticeProject.Models;
using Newtonsoft.Json;

namespace MDEV1014PracticeProject.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthService()
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

            

            
            string res = await Constants.API_SERVER
            .WithTimeout(20)
            .PostJsonAsync(sentObj)
            .ReceiveString();


            Debug.WriteLine($"Response from server:{res}");

            return JsonConvert.DeserializeObject<AuthSession>(res);

            //Debug.WriteLine($"Is there error:{resultObject.error}");
            //Debug.WriteLine($"Is there message:{resultObject.message}");


           
        }
    }
}
