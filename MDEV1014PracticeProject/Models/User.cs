using System;
namespace MDEV1014PracticeProject.Models
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string image_url { get; set; }
        public string type { get; set; }
        public string token { get; set; }
        public int age { get; set; }
    }
}
