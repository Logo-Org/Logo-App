namespace LogoAppBackend.Entities;

public class Patient : User {

    public SpeechTherapist? SpeechTherapist { get; set; }
    public ICollection<TherapyPlan> TherapyPlans { get; set; } = [];

}