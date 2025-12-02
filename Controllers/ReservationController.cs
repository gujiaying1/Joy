using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JoyRiseFitness.Models;

namespace JoyRiseFitness.Controllers
{
    public class ReservationController : Controller
    {
       
        // 假预约池 + 种子
        public static List<Reservation> _db = SeedData();

        private static List<Reservation> SeedData()
        {
            var rnd = new Random();
            var list = new List<Reservation>();
            int id = 1;
            // 今天 & 明天 两天，每小时随机塞 1-3 条
            for (int d = 0; d < 2; d++)
            {
                var date = DateTime.Today.AddDays(d);
                for (int h = 6; h <= 21; h++)
                {
                    int people = rnd.Next(1, 4);   // 1-3 人
                    list.Add(new Reservation
                    {
                        Id = id++,
                        Date = date,
                        Hour = h,
                        Count = people,
                        UserName = "seed"
                    });
                }
            }
            return list;
        }
        private static int _nextId = 1;

        // GET /Reservation
        public ActionResult Index()
        {
            // 默认显示本周 7 天
            var start = DateTime.Today;
            var days = Enumerable.Range(0, 7)
                                 .Select(i => start.AddDays(i))
                                 .ToList();
            ViewBag.Days = days;
            return View();
        }

        // 返回某天的 24 格数据  → 被 Ajax 调用
        public ActionResult GetSlots(DateTime date)
        {
            var slots = Enumerable.Range(6, 16)          // 06-21
                .Select(h => new
                {
                    hour = h,          // 必须小写
                    current = _db.Where(r => r.Date == date && r.Hour == h).Sum(r => r.Count),
                    max = Reservation.MaxPerSlot
                });
            return Json(slots, JsonRequestBehavior.AllowGet);
        }

        // 提交预约  → 弹窗 Ajax 调用
        // 提交预约 → 写真实登录名
        [HttpPost]
        public ActionResult Reserve(Reservation dto)
        {
            if (Session["uname"] == null)
                return Json(new { ok = false, msg = "请先登录" });

            if (dto.Hour < 6 || dto.Hour > 21)
                return Json(new { ok = false, msg = "时段不在开放范围" });

            var curr = _db.Where(r => r.Date == dto.Date.Date && r.Hour == dto.Hour)
                          .Sum(r => r.Count);
            if (curr + dto.Count > Reservation.MaxPerSlot)
                return Json(new { ok = false, msg = "该时段已满" });

            dto.Id = _nextId++;
            dto.Date = dto.Date.Date;
            dto.UserName = Session["uname"].ToString();   // ← 真实登录名
            _db.Add(dto);
            return Json(new { ok = true });
        }

        // 我的预约（会员中心调用）
        public ActionResult MyReservation()
        {
            if (Session["uname"] == null)
                return RedirectToAction("Login", "Member");

            var list = _db.Where(r => r.UserName == Session["uname"].ToString())
                          .OrderByDescending(r => r.Date)
                          .ThenByDescending(r => r.Hour)
                          .ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            var rec = _db.FirstOrDefault(r => r.Id == id);
            if (rec == null || rec.UserName != Session["uname"]?.ToString())
            {
                TempData["msg"] = "记录不存在或无权限";
                return RedirectToAction("MyReservation");
            }
            _db.Remove(rec);
            TempData["msg"] = "已取消";
            return RedirectToAction("MyReservation");
        }
    }
}