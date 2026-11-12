namespace LogoAppBackend.Entities;

public abstract class User : Person {

    public byte[]? Photo { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public DateTime JoinDate { get; set; }
    public ICollection<Admin> Admins { get; set; } = [];

}