using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class UserConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(a => a.Password)
                .IsRequired();
            builder.Property(a => a.RoleID)
                .HasColumnName("RoleId")
                .IsRequired();
            builder.Property(a => a.CreatedBy)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(a => a.CreatedAt)
                .HasDefaultValue()
                .ValueGeneratedOnAdd();
            builder.Property(a => a.UpdatedBy)
                .HasMaxLength(20);
            builder.Property(a => a.UpdatedAt);

            builder.HasOne(u => u.Roles)
                .WithMany(r => r.ListUsers)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ListUser_Sessions)
                .WithOne(us => us.Users)
                .HasForeignKey(us => us.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
