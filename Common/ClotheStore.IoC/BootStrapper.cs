using ClotheStore.CrossCutting.Events;
using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Register.Core.ApplicationLayer.Handlers;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.ApplicationLayer.Queries;
using Register.Core.ApplicationLayer.UseCases;
using Register.Core.DomainModel.Events;
using Register.Core.DomainModel.Interfaces.Repository;
using Register.Data.Config;
using Register.Data.Context;
using Register.Data.Repository.EF;
using SimpleInjector;
using System.Reflection;
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

            container.RegisterPerWebRequest<RegisterContext>();
            container.RegisterPerWebRequest<IUnitOfWork, RegisterUnitOfWork>();

            var domainHandler = Lifestyle.Singleton.CreateRegistration<DomainNotificationHandler>(container);
            var categoryHandler = Lifestyle.Singleton.CreateRegistration<CategoryRegisteredHandler>(container);


            //register multiple interface to same implementation (using a CreateRegistration method below)
            container.AddRegistration(typeof(IHandler<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(INotifiable<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(IHandler<CategoryRegistered>), categoryHandler);
            container.AddRegistration(typeof(INotifiable<CategoryRegistered>), categoryHandler);




            container.RegisterPerWebRequest<ICategoryManager, CategoryManager>();
            container.RegisterPerWebRequest<ICategoryQuery, CategoryQuery>();


            container.RegisterPerWebRequest<ICategoryRepository, CategoryRepository>();

        }
    }
}

