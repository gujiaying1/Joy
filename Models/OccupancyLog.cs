using System;

namespace JoyRiseFitness.Models
{
    public class OccupancyLog
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }  // 记录时刻
        public int Count { get; set; }      // 当前人数
        public int Max { get; set; } = 80;  // 上限
    }
}