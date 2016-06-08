using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UserRegistration.Identity.Model
{
    public class IdentityUserApplication : IdentityUser
    {
        public IdentityUserApplication()
        {

        }
        public IdentityUserApplication(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUserApplication> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
