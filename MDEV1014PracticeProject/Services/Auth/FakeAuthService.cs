﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MDEV1014PracticeProject.Models;

namespace MDEV1014PracticeProject.Services.Auth
{
    public class FakeAuthService : IAuthService
    {
        public FakeAuthService()
        {
        }

        public async Task<AuthSession> SignInAsync(string username, string password)
        {
            Debug.WriteLine("Mock SignInAsync");
            await Task.Delay(1000);
            if (username == Settings.mockUsername && password == Settings.mockUserPassword) {
                return new AuthSession
                {
                    error = false,
                    token = Settings.mockToken,
                    user = new User {
                        first_name = "Fake_John",
                        last_name = "Doe",
                        age = 43,
                        email = username,
                        password = password
                    }
                };

            } else {
                return new AuthSession
                {
                    error = true,
                    message = "PassMismatch"
                };
            }
            
        }
    }
}
