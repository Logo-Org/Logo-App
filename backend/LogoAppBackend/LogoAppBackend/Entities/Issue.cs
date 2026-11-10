namespace LogoAppBackend.Entities;

public class Issue {

    public long Id { get; set; }
    public IssueType IssueType { get; set; }
    public string Description { get; set; } = string.Empty;
    public byte[]? VideoRecording { get; set; }
    public byte[]? AudioRecording { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public string? Response { get; set; } = string.Empty;

}