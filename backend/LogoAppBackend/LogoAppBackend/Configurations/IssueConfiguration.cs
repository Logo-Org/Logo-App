using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue> {

    public void Configure(EntityTypeBuilder<Issue> builder) {
        builder.Property(issue => issue.Description).HasMaxLength(500);
        builder.Property(issue => issue.VideoRecording).IsRequired(false);
        builder.Property(issue => issue.AudioRecording).IsRequired(false);
        builder.Property(issue => issue.Response).HasMaxLength(500);
    }

}