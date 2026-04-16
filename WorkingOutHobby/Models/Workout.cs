namespace WorkingOutHobby.Models;

public class Workout
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public double Duration { get; set; }
    public string? Notes { get; set; }
    public int WorkoutTypeId { get; set; }
    public WorkoutType? WorkoutType { get; set; }
    public Guid UserId { get; set; }

    public User? User { get; set; }
}
