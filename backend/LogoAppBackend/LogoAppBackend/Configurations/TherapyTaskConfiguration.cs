using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class TherapyTaskConfiguration : IEntityTypeConfiguration<TherapyTask> {

    public void Configure(EntityTypeBuilder<TherapyTask> builder) {
        builder.HasMany(therapyTask => therapyTask.Sessions)
            .WithOne(session => session.TherapyTask)
            .OnDelete(DeleteBehavior.Cascade);
    }

}