using System;
namespace MDEV1014PracticeProject.Models
{
    public class AuthSession
    {
        public bool error { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
