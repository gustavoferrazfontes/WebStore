using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using UserRegistration.Identity.Model;
using Microsoft.Owin.Security.OAuth;
namespace UserRegistration.Identity.Configuration
{
    public class ConfigurationSignInManager : SignInManager<IdentityUserApplication, string>
    {
        public ConfigurationSignInManager(ApplicationUser userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static ConfigurationSignInManager Create(IdentityFactoryOptions<ConfigurationSignInManager> options, IOwinContext context)
        {
            return new ConfigurationSignInManager(context.GetUserManager<ApplicationUser>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUserApplication user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUser)UserManager, OAuthDefaults.AuthenticationType);
        }
    }
}
