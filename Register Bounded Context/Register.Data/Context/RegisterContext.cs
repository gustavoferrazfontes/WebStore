using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Register.Data.Context
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() : base("RegisterContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();

        }
    }
}
