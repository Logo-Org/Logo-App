using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class TherapyStageConfiguration : IEntityTypeConfiguration<TherapyStage> {

    public void Configure(EntityTypeBuilder<TherapyStage> builder) {
        builder.Property(therapyStage => therapyStage.EndTime)
            .IsRequired(false);
        builder.Property(therapyStage => therapyStage.Description)
            .HasMaxLength(500)
            .IsRequired(false);
    }

}