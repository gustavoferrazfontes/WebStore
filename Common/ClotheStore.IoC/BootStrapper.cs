using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using UserRegistration.Core.Domain.Model.UserAggregate.Interfaces;
using UserRegistration.Data.Context;
using UserRegistration.Data.Repository;
using UserRegistration.Identity.Configuration;
using UserRegistration.Identity.Context;
using UserRegistration.Identity.Model;

namespace ClotheStore.IoC
{
    public class BootStrapper
    {
      public static void RegisterDependencies(Container container)
        {
            container.RegisterPerWebRequest<IdentityContext>();
            container.RegisterPerWebRequest<UserRegistrationContext>();
            container.RegisterPerWebRequest<IUserStore<IdentityUserApplication>>(() => new UserStore<IdentityUserApplication>(new IdentityContext()));
            container.RegisterPerWebRequest<ApplicationUser>();
            container.RegisterPerWebRequest<ConfigurationSignInManager>();
            container.RegisterPerWebRequest<IUserRepository, UserRepository>();

        }
    }
}
