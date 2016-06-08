﻿using System.Threading.Tasks;
using Microsoft.Owin.Security.Facebook;
using System.Security.Claims;

namespace ConferenceSystem.WebApi.Security
{
    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            return Task.FromResult<object>(null);
        }
    }
}