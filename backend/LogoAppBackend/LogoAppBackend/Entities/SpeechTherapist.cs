using System.ComponentModel.DataAnnotations;

namespace LogoAppBackend.Entities;

public class SpeechTherapist : User {

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    public List<string> Links { get; set; } = [];
    public Address? Address { get; set; }
    public ICollection<Patient> Patients { get; set; } = [];
    public ICollection<Credential> Credentials { get; set; } = [];

}