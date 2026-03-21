namespace WorkingOutHobby.Models;

public class WorkoutType
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Workout> Workouts { get; set; } = [];
}
