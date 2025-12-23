using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configurations
{
    public class LetterRecipientConfiguration : IEntityTypeConfiguration<LetterRecipient>
    {
        public void Configure(EntityTypeBuilder<LetterRecipient> builder)
        {
            builder.ToTable("LetterRecipient");
builder.HasKey(lr => lr.Id); 
        

        builder.HasIndex(lr => new { lr.LetterId, lr.RecipientId }).IsUnique();

     
        builder.HasOne(lr => lr.Letter)
               .WithMany(l => l.Recipients)
               .HasForeignKey(lr => lr.LetterId)
               .OnDelete(DeleteBehavior.Cascade); 

  
        builder.HasOne(lr => lr.Recipient)
               .WithMany(u => u.ReceivedLetters) 
               .HasForeignKey(lr => lr.RecipientId)
               .OnDelete(DeleteBehavior.Restrict);

      
        builder.HasOne(lr => lr.ForwarderUser)
               .WithMany() 
               .HasForeignKey(lr => lr.ForwardedByUserId)
               .IsRequired(false) 
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
