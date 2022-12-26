using Microsoft.AspNetCore.Identity;

namespace be.MbDevelompent.Greenmaster.Statics.Users
{
    public class Role : IdentityRole<Guid>
    {
        public bool IsDeleted { get; set; } = false;

        public Role()
        {

        }
        public Role(string roleName,string companyName) : base(roleName)
        {
            
        }
    }
}