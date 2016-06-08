using ConferenceSystem.WebApi;
using ConferenceSystem.WebApi.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using UserRegistration.Identity.Configuration;


[assembly: OwinStartup(typeof(Startup))]
namespace ConferenceSystem.WebApi
{

    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public static void Configuration(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.CreatePerOwinContext(() => GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ApplicationUser)) as ApplicationUser);

            PublicClientId = "self";

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString(@"/api/security/token"),
                Provider = new SimpleAuthorizationServerProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                AllowInsecureHttp = true
                
                

            };

            // Token Generation
            app.UseOAuthBearerTokens(OAuthOptions);
            //app.UseOAuthAuthorizationServer(OAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());



        }

    }



}