using LogoAppBackend.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogoAppBackend.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise> {

    public void Configure(EntityTypeBuilder<Exercise> builder) {
        builder.Property(exercise => exercise.VideoRecordingInstruction).IsRequired(false);
        builder.Property(exercise => exercise.StepByStepInstruction).IsRequired(false);
        builder.HasMany(exercise => exercise.TherapyTasks)
            .WithOne(therapyTask => therapyTask.Exercise)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(exercise => exercise.Tags)
            .WithMany(tag => tag.Exercises)
            .UsingEntity(join => join.ToTable("ExerciseTag"));
    }

}