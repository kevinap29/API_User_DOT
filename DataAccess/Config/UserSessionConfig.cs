using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class UserSessionConfig : IEntityTypeConfiguration<User_Sessions>
    {
        public void Configure(EntityTypeBuilder<User_Sessions> builder)
        {
            builder.ToTable("User_Sessions");
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Token)
                .IsRequired();
            builder.Property(a => a.ValidUntil)
                .IsRequired();
            builder.Property(a => a.UserID)
                .HasColumnName("UserID")
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

            builder.HasOne(us => us.Users)
                .WithMany(u => u.ListUser_Sessions)
                .HasForeignKey(us => us.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
