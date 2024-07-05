using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder) 
        {
            builder.ToTable("Roles");
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.RoleLevel)
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

            builder.HasMany(r => r.ListUsers)
                .WithOne(u => u.Roles)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
