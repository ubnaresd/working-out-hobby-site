namespace WorkingOutHobby.Models;

public class Workout
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Duration { get; set; }
    public string? Notes { get; set; }
    public int WorkoutTypeId { get; set; }
    public required WorkoutType WorkoutType { get; set; }
}
