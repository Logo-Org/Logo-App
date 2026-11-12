using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person> {

    public void Configure(EntityTypeBuilder<Person> builder) {
        builder.Property(person => person.FirstName).HasMaxLength(50);
        builder.Property(person => person.MiddleName)
            .IsRequired(false)
            .HasMaxLength(50);
        builder.Property(person => person.LastName).HasMaxLength(100);
        builder.Ignore(person => person.Age);
        builder.ComplexProperty(person => person.Contact, contact => {
            contact.Property(c => c.PhoneNumber).HasMaxLength(20);
            contact.Property(c => c.Email).HasMaxLength(254);
        });
    }

}