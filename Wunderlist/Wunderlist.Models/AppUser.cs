using Microsoft.AspNet.Identity;

namespace Wunderlist.Models
{
    public class AppUser : IUser<int>
    {       
        public int Id { get; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
        public int UserProfileId { get; set; }
    }
}
