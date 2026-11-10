namespace LogoAppBackend.Entities;

public class Session {

    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public required Task Task { get; set; }
    public Issue? Issue { get; set; }

}