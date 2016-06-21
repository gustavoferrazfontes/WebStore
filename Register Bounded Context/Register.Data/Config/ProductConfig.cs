using Register.Core.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Register.Data.Config
{
    public sealed class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasKey(_ => _.Id);

            Property(_ => _.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(_ => _.Title)
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();


            Property(_ => _.Description)
                .HasColumnType("varchar")
                .HasMaxLength(1024)
                .IsRequired();

            Property(_ => _.Image);

            Property(_ => _.QuantityInStock)
                .IsRequired();

            HasRequired(_ => _.Category);

            ToTable("Product");




        }
    }
}
