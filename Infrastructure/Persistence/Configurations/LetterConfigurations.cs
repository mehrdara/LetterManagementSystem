
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Domain.EntityPropertyConfigurations;

namespace Infrastructure.Persistence.Configurations
{
    public class LetterConfigurations : IEntityTypeConfiguration<Letter>
    {

        public void Configure(EntityTypeBuilder<Letter> builder)
        {

            builder.HasKey(l => l.Id);
            builder.Property(x => x.Id)
           .UseIdentityColumn(1, 1);
            builder.HasOne(l => l.Sender)
                           .WithMany(u => u.SentLetters)
                           .HasForeignKey(l => l.SenderId)
                           .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(t => t.HasCheckConstraint("CK_Letter_Subject_NotEmpty", "LEN(TRIM(Subject)) > 0"));
            builder.ToTable(t => t.HasCheckConstraint("CK_Letter_Body_NotEmpty", "LEN(TRIM(Body)) > 0"));
            builder.ToTable(t => t.HasCheckConstraint("CK_Letter_Type", "[LetterType] IN (1, 2, 3)"));
            builder.Property(u => u.Subject).HasMaxLength(LetterPropertyConfiguration.SubjectMaxLength).IsRequired();
            builder.Property(u => u.Body).IsRequired();
            builder.HasOne(l => l.ParentLetter)
                    .WithMany(l => l.Replies)
                    .HasForeignKey(l => l.ParentLetterId)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.ParentLetterId).IsRequired(false);
            builder.Metadata.FindNavigation(nameof(Letter.Recipients))
        ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}



