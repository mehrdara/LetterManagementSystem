using System.Reflection;
using Domain.Common;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        private readonly ICurrentUserService _currentUserService;
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<LetterRecipient> LetterRecipients { get; set; }

        public DbSet<Letter> Letters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
var passwordHasher = new PasswordHasher<AppUser>(); 
var seedUsers = new List<AppUser>();

for (int i = 1; i <= 10; i++)
{
    var user = new AppUser
    {
        Id = i,
        FirstName="Mehr",
        LastName="Dara",
        OrganizationMail="mehrdara@gmail.com",
        UserName = $"mehrdara{i}",
        NormalizedUserName = $"MEHRDARA{i}".ToUpper(),
        Email = $"mehrdara{i}@gmail.com",
        NormalizedEmail = $"MEHRDARA{i}@GMAIL.COM".ToUpper(),
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ConcurrencyStamp = Guid.NewGuid().ToString() 
    };

    user.PasswordHash = passwordHasher.HashPassword(user, "Password123!");

    seedUsers.Add(user);
}
modelBuilder.Entity<AppUser>().HasData(seedUsers);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();
            Console.WriteLine(entries);
            foreach (var entry in entries)
            {
                var now = DateTime.UtcNow;
                var userId = _currentUserService.UserId ?? 0;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateTime = now;
                        entry.Entity.CreatedUserId = userId;
                        break;
                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDateTime).IsModified = false;
                        entry.Property(x => x.CreatedUserId).IsModified = false;
                        entry.Entity.ModifiedDateTime = now;
                        entry.Entity.ModifiedUserId = userId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);


        }
    }
}
