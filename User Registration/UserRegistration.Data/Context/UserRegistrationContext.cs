using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UserRegistration.Core.Domain.Model.Model.UserAggregate;
using UserRegistration.Data.Config;

namespace UserRegistration.Data.Context
{
    public class UserRegistrationContext : DbContext
    {
        public UserRegistrationContext() : base("UserRegistrationConnection")
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
