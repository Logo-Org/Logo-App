namespace LogoAppBackend.Entities;

public class Admin : Person {

    public ICollection<User> Users { get; set; } = [];
    public ICollection<Exercise> Exercises { get; set; } = [];

}