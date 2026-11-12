namespace LogoAppBackend.Entities;

public class SpeechTherapist : User {

    public string Description { get; set; } = string.Empty;

    public List<string> Links { get; set; } = [];
    public Address? Address { get; set; }
    public long PatientId { get; set; }
    public ICollection<Patient>? Patients { get; set; } = [];
    public ICollection<Credential> Credentials { get; set; } = [];

}