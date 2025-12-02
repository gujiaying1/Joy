namespace JoyRiseFitness.Models
{
    public enum MusclePart
    {
        Chest,
        Back,
        Legs,
        Arms,
        Shoulders,
        Core
    }

    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusclePart Part { get; set; }
        public string ImgUrl { get; set; }   // 可存外链
        public string Difficulty { get; set; } // 初级/中级/高级
        public string ShortDesc { get; set; }
    }
}