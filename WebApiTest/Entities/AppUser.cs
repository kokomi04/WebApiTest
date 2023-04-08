using Microsoft.AspNetCore.Identity;

namespace WebApiTest.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
    }
}
