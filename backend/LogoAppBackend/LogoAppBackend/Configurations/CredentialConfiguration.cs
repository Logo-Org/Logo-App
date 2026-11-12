using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class CredentialConfiguration : IEntityTypeConfiguration<Credential> {

    public void Configure(EntityTypeBuilder<Credential> builder) {
        builder.Property(credential => credential.LicenseNumber).HasMaxLength(100);
        builder.HasOne(credential => credential.SpeechTherapist)
            .WithMany(speechTherapist => speechTherapist.Credentials);
    }

}