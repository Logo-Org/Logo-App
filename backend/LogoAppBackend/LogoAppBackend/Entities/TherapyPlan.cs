namespace LogoAppBackend.Entities;

public class TherapyPlan {

    public long Id { get; set; }
    public string GoalDescription { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public long PatientId { get; set; }
    public required Patient Patient { get; set; }
    public long TherapyTaskId { get; set; }
    public ICollection<TherapyTask> TherapyTasks { get; set; } = [];
    public long DisorderId { get; set; }
    public ICollection<Disorder> Disorders { get; set; } = [];
    public long TherapyStageId { get; set; }
    public ICollection<TherapyStage> TherapyStages { get; set; } = [];

}