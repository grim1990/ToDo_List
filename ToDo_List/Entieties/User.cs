using Microsoft.AspNetCore.Identity;

namespace ToDo_List.Entieties
{
    public class User
    {
        public class ApplicationUser : IdentityUser
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
