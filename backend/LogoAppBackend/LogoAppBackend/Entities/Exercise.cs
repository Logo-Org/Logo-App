namespace LogoAppBackend.Entities;

public class Exercise {

    public long Id { get; set; }
    public byte[]? VideoRecordingInstruction { get; set; }
    public TimeSpan Duration { get; set; }
    public List<string>? StepByStepInstruction { get; set; }
    public HashSet<Tag> Tags { get; set; } = [];
    public ICollection<TherapyTask> Tasks { get; set; } = [];
    public Admin Admin { get; set; }

}