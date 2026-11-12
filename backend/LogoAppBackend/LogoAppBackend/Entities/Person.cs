namespace LogoAppBackend.Entities;

public abstract class Person {

    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public int Age => DateTime.Today.Year - DateOfBirth.Year;

    public required Contact Contact { get; set; }

}