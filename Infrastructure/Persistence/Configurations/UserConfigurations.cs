
using Domain.Entities;
using Domain.EntityPropertyConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(l => l.Id);
            builder.Property(x => x.Id)
           .UseIdentityColumn(1, 1);

            builder.Property(u => u.FirstName)
            .HasMaxLength(UserPropertyConfiguration.FirstNameMaxLength)
            .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(UserPropertyConfiguration.LastNameMaxLength)
                .IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasIndex(p => p.UserName).IsUnique();

        }
    }
}
