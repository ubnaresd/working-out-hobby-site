using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace WorkingOutHobby.Models;

public class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

    public DbSet<WorkoutType> WorkoutTypes { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkoutType>().HasData(
            new WorkoutType { Id = 1, Name = "Strength" },
            new WorkoutType { Id = 2, Name = "Cardio" },
            new WorkoutType { Id = 3, Name = "HIIT" },
            new WorkoutType { Id = 4, Name = "Flexibility" }
        );
    }
}
