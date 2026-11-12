namespace LogoAppBackend.Entities;

public class Exercise {

    public long Id { get; set; }
    public byte[]? VideoRecordingInstruction { get; set; }
    public TimeSpan Duration { get; set; }
    public List<string>? StepByStepInstruction { get; set; }
    public HashSet<Tag> Tags { get; set; } = [];
    public long AdminId { get; set; }
    public Admin Admin { get; set; }
    public long TherapyTaskId { get; set; }
    public ICollection<TherapyTask> TherapyTasks { get; set; } = [];

}