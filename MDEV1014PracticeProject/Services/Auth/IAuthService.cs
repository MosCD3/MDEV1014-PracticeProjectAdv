﻿using System;
using System.Threading.Tasks;
using MDEV1014PracticeProject.Models;

namespace MDEV1014PracticeProject.Services.Auth
{
    public interface IAuthService
    {
        User activeUser { get; set; }
        Task<AuthSession> SignInAsync(string username, string password);
        void SetActiveUser(User user);
        bool Signout();
    }
}
