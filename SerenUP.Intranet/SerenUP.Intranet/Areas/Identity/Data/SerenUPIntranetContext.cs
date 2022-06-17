using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SerenUP.Intranet.Data;

public class SerenUPIntranetContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public SerenUPIntranetContext(DbContextOptions<SerenUPIntranetContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "User");
            entity.Property(e => e.Id).HasColumnName("UserId");
        });

        builder.Entity<ApplicationRole>(entity =>
        {
            entity.ToTable(name: "Role");
            entity.Property(e => e.Id).HasColumnName("RoleId");
        });

        builder.Entity<IdentityUserRole<Guid>>(entity =>
        {
            entity.ToTable("UserRoles");
            //in case you chagned the TKey type
            //entity.HasKey(key => new { key.UserId, key.RoleId });
        });

        builder.Entity<IdentityUserClaim<Guid>>(entity =>
        {
            entity.ToTable("UserClaims");
        });

        builder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
            entity.ToTable("UserLogins");
            //in case you chagned the TKey type
            //entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });
        });

        builder.Entity<IdentityRoleClaim<Guid>>(entity =>
        {
            entity.ToTable("RoleClaims");

        });

        builder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.ToTable("UserTokens");
            //in case you chagned the TKey type
            //entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });

        });
    }
}

public class ApplicationUser : IdentityUser<Guid>
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}

public class ApplicationRole : IdentityRole<Guid>
{
    public string Description { get; set; }
}