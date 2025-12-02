using System;
using System.ComponentModel.DataAnnotations;

namespace JoyRiseFitness.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }         // 预约日期

        [Range(6, 21)]
        public int Hour { get; set; }              // 06-21 整点

        public string UserName { get; set; }       // 当前登录用户（Session）

        public int Count { get; set; } = 1;       // 人数，默认 1

        // 每时段最大人数（常量）
        public const int MaxPerSlot = 30;
    }
}