namespace LogoAppBackend.Entities;

public class Patient : User {

    public long? SpeechTherapistId { get; set; }
    public SpeechTherapist? SpeechTherapist { get; set; }
    public ICollection<TherapyPlan> TherapyPlans { get; set; } = [];

}