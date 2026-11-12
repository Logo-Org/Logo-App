using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class SpeechTherapistConfiguration : IEntityTypeConfiguration<SpeechTherapist> {

    public void Configure(EntityTypeBuilder<SpeechTherapist> builder) {
        builder.ComplexProperty(speechTherapist => speechTherapist.Address, address => {
            address.Property(a => a.Street).HasMaxLength(100);
            address.Property(a => a.City).HasMaxLength(50);
            address.Property(a => a.ZipCode).HasMaxLength(10);
            address.Property(a => a.Country).HasMaxLength(30);
            address.IsRequired(false);
        });
        builder.Property(speechTherapist => speechTherapist.Description).HasMaxLength(100);
        builder.HasMany(speechTherapist => speechTherapist.Credentials)
            .WithOne(credential => credential.SpeechTherapist)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(speechTherapist => speechTherapist.Patients)
            .WithOne(patient => patient.SpeechTherapist)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }

}