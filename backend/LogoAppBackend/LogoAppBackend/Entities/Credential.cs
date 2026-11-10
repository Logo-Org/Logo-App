namespace LogoAppBackend.Entities;

public class Credential {

    public long Id { get; set; }
    public required DocumentStatus DocumentStatus { get; set; }
    public required byte[] Document { get; set; }
    public required SpeechTherapist SpeechTherapist { get; set; }

}