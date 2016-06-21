using Register.Core.DomainModel;
using Register.Data.Config;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Register.Data.Context
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() : base("RegisterContext")
        {

        }

        public DbSet<Category> Categories { get;  set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ProductConfig());

        }
    }
}
