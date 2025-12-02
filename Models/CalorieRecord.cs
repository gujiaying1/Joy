using System;

namespace JoyRiseFitness.Models
{
    public class CalorieRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime Date { get; set; }
    }
}