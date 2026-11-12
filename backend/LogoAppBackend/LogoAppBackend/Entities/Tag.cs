namespace LogoAppBackend.Entities;

public abstract class Tag {

    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<Exercise> Exercises { get; set; } = [];

}