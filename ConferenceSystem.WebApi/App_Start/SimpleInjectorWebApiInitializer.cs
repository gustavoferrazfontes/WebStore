namespace ConferenceSystem.WebApi.App_Start
{
    using ClotheStore.IoC;
    using ClotheStore.SharedKernel.Events;
    using Helpers;
    using Microsoft.Owin;
    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Integration.WebApi;
    using System.Web;
    using System.Web.Http;

    public static class SimpleInjectorWebApiInitializer
    {

        public static void Initialize(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Chamada dos m�dulos do Simple Injector
            BootStrapper.RegisterDependencies(container);

            // Necess�rio para registrar o ambiente do Owin que � depend�ncia do Identity
            // Feito fora da camada de IoC para n�o levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;


            });

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            DomainEvent.Container = new DomainEventsContainer(config.DependencyResolver);

        }
    }
}