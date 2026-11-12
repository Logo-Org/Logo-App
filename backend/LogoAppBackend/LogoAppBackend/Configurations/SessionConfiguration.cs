using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session> {

    public void Configure(EntityTypeBuilder<Session> builder) {
        builder.HasOne(session => session.Issue)
            .WithOne(issue => issue.Session)
            .HasForeignKey<Issue>(issue => issue.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}