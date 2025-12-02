
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JoyRiseFitness.Models;

namespace JoyRiseFitness.Controllers
{
    public class OccupancyController : Controller
    {
        // 公开静态字段，让当前人数计算能吃到预约数据
        public static List<Reservation> ReservationSource
            => ReservationController._db;   // 指向预约控制器的静态池

        // 静态假数据池
        private static List<OccupancyLog> _log = GenFakeLogs();
        private static int _nextId = 1000;

        // 页面
        public ActionResult Index() => View();

        // 接口：最近 24h 数据（JSON）
        public ActionResult GetCurrent()
        {
            var since = DateTime.Now.AddHours(-24);
            var data = _log.Where(l => l.Time >= since)
                           .OrderBy(l => l.Time)
                           .Select(l => new { l.Time, l.Count, l.Max })
                           .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // 供 JS 每 30 秒调用的抓拍接口（也吃预约数据）
        public ActionResult Snap()
        {
            var curr = ReservationSource
                       .Where(r => r.Date == DateTime.Today &&
                                   r.Hour == DateTime.Now.Hour)
                       .Sum(r => r.Count);
            curr = Math.Max(0, Math.Min(80, curr + new Random().Next(-3, 4)));

            // 顺便写一条新日志（可选）
            _log.Add(new OccupancyLog
            {
                Id = _nextId++,
                Time = DateTime.Now,
                Count = curr
            });
            return Json(new { ok = true, count = curr }, JsonRequestBehavior.AllowGet);
        }

        // 首次生成 24h 假日志（用预约算 + 噪点）
        private static List<OccupancyLog> GenFakeLogs()
        {
            var rnd = new Random();
            var logs = new List<OccupancyLog>();
            var start = DateTime.Now.AddHours(-24);
            for (int i = 0; i <= 96; i++)          // 15 分钟一条
            {
                var t = start.AddMinutes(i * 15);
                // 用同一小时的预约总和当「当前人数」
                int baseCount = ReservationSource
                                .Where(r => r.Date == t.Date && r.Hour == t.Hour)
                                .Sum(r => r.Count);
                logs.Add(new OccupancyLog
                {
                    Id = i + 1,
                    Time = t,
                    Count = Math.Max(0, Math.Min(80, baseCount + rnd.Next(-5, 6)))
                });
            }
            return logs;
        }
    }
}