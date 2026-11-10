namespace LogoAppBackend.Entities;

public class Task {

    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public int Series { get; set; }
    public int Repetition { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public DateTime PeriodStartTime { get; set; }
    public DateTime PeriodEndTime { get; set; }
    public int MaxSessionPerPeriod { get; set; }
    public required TherapyPlan TherapyPlan { get; set; }
    public required Exercise Exercise { get; set; }
    public ICollection<Session> Sessions { get; set; } = [];

}