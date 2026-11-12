namespace LogoAppBackend.Entities;

public class Disorder : Tag {

    public DisorderCategory DisorderCategory { get; set; }
    public ICollection<TherapyPlan> TherapyPlans { get; set; } = [];

}