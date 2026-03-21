namespace WorkingOutHobby.Models;

public class ProgressViewModel
{
    public Workout Workout { get; set; } = new();
    public List<WorkoutType> WorkoutTypes { get; set; } = [];
    public List<Workout> History { get; set; } = [];
}
