using System.ComponentModel.DataAnnotations;

namespace LogoAppBackend.Entities;

public abstract class Person {

    public long Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public int Age => DateTime.Today.Year - DateOfBirth.Year;

    public required Contact Contact { get; set; }

}