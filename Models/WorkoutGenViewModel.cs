using System.Collections.Generic;

namespace JoyRiseFitness.Models
{
    public enum Goal { LoseFat, BuildMuscle, Strength, Endurance }
    public enum Level { Beginner, Intermediate, Advanced }
    public enum Gender { Male, Female, Other }

    public class WorkoutGenViewModel
    {
        public Gender? Gender { get; set; }
        public int? Age { get; set; } = 25;
        public Goal? Goal { get; set; }
        public Level? Level { get; set; }
        public MusclePart? Part { get; set; }

        public List<Workout> Generated { get; set; } = new List<Workout>();
    }
}