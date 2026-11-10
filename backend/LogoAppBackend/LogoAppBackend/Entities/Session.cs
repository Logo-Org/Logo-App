namespace LogoAppBackend.Entities;

public class Session {

    public long Id { get; set; }
    public DateTime Timestamp { get; set; }
    public required TherapyTask TherapyTask { get; set; }
    public Issue? Issue { get; set; }

}