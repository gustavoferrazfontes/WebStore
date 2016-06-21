using Register.Core.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Register.Data.Config
{
    public sealed class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {

            HasKey(_ => _.Id);

            Property(_ => _.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(_ => _.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            ToTable("Category");
        }
    }
}
