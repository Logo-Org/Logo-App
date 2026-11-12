using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class TherapyPlanConfiguration : IEntityTypeConfiguration<TherapyPlan> {

    public void Configure(EntityTypeBuilder<TherapyPlan> builder) {
        builder.Property(therapyPlan => therapyPlan.GoalDescription).HasMaxLength(500);
        builder.Property(therapyPlan => therapyPlan.EndTime).IsRequired(false);
        builder.HasMany(therapyPlan => therapyPlan.TherapyTasks)
            .WithOne(therapyTask => therapyTask.TherapyPlan)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(therapyPlan => therapyPlan.TherapyStages)
            .WithOne(therapyStage => therapyStage.TherapyPlan)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(therapyPlan => therapyPlan.Disorders)
            .WithMany(disorder => disorder.TherapyPlans)
            .UsingEntity(join => join.ToTable("DisorderTherapyPlan"));
    }

}