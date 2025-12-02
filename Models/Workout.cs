using System.Collections.Generic;

namespace JoyRiseFitness.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusclePart Part { get; set; }
        public string Difficulty { get; set; }
        public string ImgUrl { get; set; }
        public List<string> Steps { get; set; } = new List<string>();
        public List<string> Alternatives { get; set; } = new List<string>();

        public string ShortDesc { get; set; }
    }
}