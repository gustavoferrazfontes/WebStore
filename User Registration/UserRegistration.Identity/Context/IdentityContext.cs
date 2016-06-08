using Microsoft.AspNet.Identity.EntityFramework;
using System;
using UserRegistration.Identity.Model;

namespace UserRegistration.Identity.Context
{
    public class IdentityContext : IdentityDbContext<IdentityUserApplication>, IDisposable
    {
        public IdentityContext() : base("UserRegistrationConnection", throwIfV1Schema: false)
        {

        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
