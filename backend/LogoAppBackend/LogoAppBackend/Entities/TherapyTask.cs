namespace LogoAppBackend.Entities;

public class TherapyTask {

    public long Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Series { get; set; }
    public int Repetition { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public DateTime PeriodStartTime { get; set; }
    public DateTime PeriodEndTime { get; set; }
    public int MaxSessionsPerPeriod { get; set; }
    public long TherapyPlanId { get; set; }
    public required TherapyPlan TherapyPlan { get; set; }
    public long ExerciseId { get; set; }
    public required Exercise Exercise { get; set; }
    public long SessionId { get; set; }
    public ICollection<Session> Sessions { get; set; } = [];

}