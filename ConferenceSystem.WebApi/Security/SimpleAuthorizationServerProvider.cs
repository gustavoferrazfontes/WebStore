using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Identity.Configuration;

namespace ConferenceSystem.WebApi.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private ApplicationUser _applicationUser;
        private readonly string _publicClientId;

        public SimpleAuthorizationServerProvider(string publicClientId)
        {

            if (publicClientId == null)
                throw new ArgumentNullException(@"publicClientId");

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            _applicationUser = context.OwinContext.GetUserManager<ApplicationUser>();
            var user = await _applicationUser.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }

            var identity = await user.GenerateUserIdentityAsync(_applicationUser, OAuthDefaults.AuthenticationType);
            var cookiesIdentity = await user.GenerateUserIdentityAsync(_applicationUser, CookieAuthenticationDefaults.AuthenticationType);
            var properties = CreateProperties(user.UserName);
            var ticket = new AuthenticationTicket(identity, properties);
            var principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}