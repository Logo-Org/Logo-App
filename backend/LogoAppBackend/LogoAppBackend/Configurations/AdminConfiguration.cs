using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin> {

    public void Configure(EntityTypeBuilder<Admin> builder) {
        builder.HasMany(admin => admin.Users)
            .WithMany(user => user.Admins)
            .UsingEntity(join => join.ToTable("UserAdmin"));
        builder.HasMany(admin => admin.Exercises)
            .WithOne(exercise => exercise.Admin)
            .OnDelete(DeleteBehavior.SetNull);
    }

}