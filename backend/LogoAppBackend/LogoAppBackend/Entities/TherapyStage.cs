namespace LogoAppBackend.Entities;

public class TherapyStage {

    public long Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public TherapyStageStatus TherapyStageStatus { get; set; }
    public long TherapyPlanId { get; set; }
    public TherapyPlan TherapyPlan { get; set; }

}