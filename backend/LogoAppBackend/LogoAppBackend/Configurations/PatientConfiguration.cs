using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient> {

    public void Configure(EntityTypeBuilder<Patient> builder) {
        builder.HasMany(patient => patient.TherapyPlans)
            .WithOne(therapyPlan => therapyPlan.Patient)
            .OnDelete(DeleteBehavior.Cascade);
    }

}