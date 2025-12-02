using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JoyRiseFitness.Models;

namespace JoyRiseFitness.Controllers
{
    public class EquipmentController : Controller
    {
        private const int PageSize = 6;
        private static readonly List<Equipment> _db = new List<Equipment>
        {
            new Equipment{Id=1, Name="Barbell Bench Press",      Part=MusclePart.Chest,    Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1581009137042-c552e485697a?w=640", ShortDesc="Compound move for bigger chest."},
            new Equipment{Id=2, Name="Dumbbell Shoulder Press",  Part=MusclePart.Shoulders,Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=640", ShortDesc="Build rounded delts."},
            new Equipment{Id=3, Name="Lat Pull-down",            Part=MusclePart.Back,     Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=640", ShortDesc="Vertical pull for V-back."},
            new Equipment{Id=4, Name="Leg Press",                Part=MusclePart.Legs,     Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1558611848-73f7eb4001a1?w=640", ShortDesc="Safe machine squat."},
            new Equipment{Id=5, Name="Cable Biceps Curl",        Part=MusclePart.Arms,     Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1518611012118-696072aa579a?w=640", ShortDesc="Constant tension for arms."},
            new Equipment{Id=6, Name="Plank",                    Part=MusclePart.Core,     Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1518310383802-640c2de311b2?w=640", ShortDesc="Core activation & spine safety."},
            new Equipment{Id=7, Name="Smith Machine Squat",      Part=MusclePart.Legs,     Difficulty="Intermediate",ImgUrl="https://images.unsplash.com/photo-1541534741688-6078c6bfb5c5?w=640", ShortDesc="Guided heavy squat."},
            new Equipment{Id=8, Name="Cable Wood-chop",          Part=MusclePart.Core,     Difficulty="Intermediate",ImgUrl="https://images.unsplash.com/photo-1574680096145-d05b474e2155?w=640", ShortDesc="Rotational core power."},
            new Equipment{Id=9, Name="Hip Thrust",               Part=MusclePart.Legs,     Difficulty="Intermediate",ImgUrl="https://images.unsplash.com/photo-1599058945522-28d584b6f0ff?w=640", ShortDesc="Best glute builder."},
            new Equipment{Id=10,Name="Pec Deck Fly",            Part=MusclePart.Chest,    Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=640", ShortDesc="Isolate chest fibers."},
            new Equipment{Id=11,Name="Seated Row",              Part=MusclePart.Back,     Difficulty="Beginner",  ImgUrl="https://plus.unsplash.com/premium_photo-1661962287338-a228bb258cb2?q=80&w=1171&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", ShortDesc="Horizontal pull for thickness."},
            new Equipment{Id=12,Name="Triceps Push-down",       Part=MusclePart.Arms,     Difficulty="Beginner",  ImgUrl="https://images.unsplash.com/photo-1530822847156-5df684ec5ee1?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", ShortDesc="Isolate triceps with cable."}
        };

        public ActionResult Index(string q, MusclePart? part, string sort, int p = 1)
        {
            var data = _db.AsEnumerable();

            if (!string.IsNullOrEmpty(q))
                data = data.Where(e => e.Name.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
            if (part.HasValue)
                data = data.Where(e => e.Part == part);

            switch (sort)
            {
                case "diff-desc":
                    data = data.OrderByDescending(e => e.Difficulty);
                    break;
                case "diff-asc":
                    data = data.OrderBy(e => e.Difficulty);
                    break;
                default:
                    data = data.OrderBy(e => e.Id);
                    break;
            }

            int total = data.Count();
            int maxPage = (int)Math.Ceiling(total / (double)PageSize);
            p = Math.Max(1, Math.Min(p, maxPage));
            data = data.Skip((p - 1) * PageSize).Take(PageSize);

            ViewBag.Query = q;
            ViewBag.Part = part;
            ViewBag.Sort = sort;
            ViewBag.Page = p;
            ViewBag.MaxPage = maxPage;

            return View(data.ToList());
        }

        // 修复Detail方法，使用可空参数
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                // 如果没有提供id，重定向到列表页
                return RedirectToAction("Index");
            }

            var item = _db.FirstOrDefault(e => e.Id == id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
    }
}