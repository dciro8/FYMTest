using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;

namespace UserManager.Infrastructure.Context;

public partial class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {     
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DocumentType).HasMaxLength(5);
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).   HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.State).ValueGeneratedNever().HasDefaultValue(null);
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdentificaionCode).HasMaxLength(5);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.State).ValueGeneratedNever().HasDefaultValue(null);
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
