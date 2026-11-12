using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;

namespace LogoAppBackend.Data;

public class AppDbContext : DbContext {

    protected AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Person> Person { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Admin> Admin { get; set; }
    public DbSet<SpeechTherapist> SpeechTherapist { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Credential> Credential { get; set; }
    public DbSet<TherapyPlan> TherapyPlan { get; set; }
    public DbSet<TherapyStage> TherapyStage { get; set; }
    public DbSet<TherapyTask> TherapyTasks { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Session> Session { get; set; }
    public DbSet<Issue> Issue { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Disorder> Disorder { get; set; }
    public DbSet<BodyPart> BodyPart { get; set; }
    public DbSet<SpeechSound> SpeechSound { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder.Properties<Enum>().HaveConversion<string>().HaveMaxLength(50);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}