using CleanArchitecture.Stsutsul.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Stsutsul.Persistence.Configurations
{
    public class SemenConfiguration : IEntityTypeConfiguration<Semen>
    {
        public void Configure(EntityTypeBuilder<Semen> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);

            builder.HasMany(x => x.Books).WithOne(x => x.Semen).HasForeignKey(x => x.SemenId);
        }
    }
}