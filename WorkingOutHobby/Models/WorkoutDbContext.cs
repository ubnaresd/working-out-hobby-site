using Microsoft.EntityFrameworkCore;

namespace WorkingOutHobby.Models;

public class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

    public DbSet<WorkoutType> WorkoutTypes { get; set; }
    public DbSet<Workout> Workouts { get; set; }
}
