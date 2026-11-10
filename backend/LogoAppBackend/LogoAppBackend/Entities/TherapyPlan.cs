namespace LogoAppBackend.Entities;

public class TherapyPlan {

    public long Id { get; set; }
    public string GoalDescription { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public required Patient Patient { get; set; }
    public ICollection<Task> Tasks { get; set; } = [];
    public ICollection<Disorder> Disorders { get; set; } = [];
    public ICollection<TherapyStage> TherapyStages { get; set; } = [];

}