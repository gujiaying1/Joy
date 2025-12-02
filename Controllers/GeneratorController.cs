using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JoyRiseFitness.Models;

namespace JoyRiseFitness.Controllers
{
    public class GeneratorController : Controller
    {

        public ActionResult Index1()
        {
            System.IO.File.AppendAllText(Server.MapPath("~/log.txt"), "Index 进了\r\n");
            return View(new WorkoutGenViewModel());
        }
        private static readonly List<Workout> _db = WorkoutSeed.Seed();

        // 首页
        public ActionResult Index() => View(new WorkoutGenViewModel());

        // 生成动作（AJAX）
        // 生成动作（AJAX）
        [HttpPost]
        public ActionResult Generate(WorkoutGenViewModel vm)
        {
            try
            {
                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"), $"Generate called: Part={vm.Part}, Level={vm.Level}, Goal={vm.Goal}\r\n");

                var q = _db.AsEnumerable();
                if (vm.Part.HasValue) q = q.Where(w => w.Part == vm.Part);
                if (vm.Level.HasValue) q = q.Where(w => w.Difficulty == vm.Level.ToString());
                if (vm.Goal.HasValue) q = GoalFilter(q, vm.Goal.Value);

                var generated = q.OrderBy(x => Guid.NewGuid()).Take(6).ToList();
                vm.Generated = generated;

                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"), $"Generated {generated.Count} items\r\n");

                return PartialView("_GeneratedList", generated);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"), $"Error: {ex}\r\n");
                return Content("<p>Error generating workout plan. Please try again.</p>");
            }
        }

        // 目标过滤（C# 7.3 传统 switch）
        private IEnumerable<Workout> GoalFilter(IEnumerable<Workout> src, Goal g)
        {
            switch (g)
            {
                case Goal.LoseFat:
                    return src.Where(w => w.Part == MusclePart.Core || w.Part == MusclePart.Legs);
                case Goal.BuildMuscle:
                    return src.Where(w => w.Part == MusclePart.Chest || w.Part == MusclePart.Arms);
                case Goal.Strength:
                    return src.Where(w => w.Difficulty != "Beginner");
                case Goal.Endurance:
                    return src.Where(w => w.Part == MusclePart.Back || w.Part == MusclePart.Legs);
                default:
                    return src;
            }
        }

        #region 收藏计划
        [HttpPost]
        public ActionResult SavePlan(List<int> ids)
        {
            var plan = Session["MyPlan"] as List<Workout> ?? new List<Workout>();
            var add = _db.Where(w => ids.Contains(w.Id)).ToList();
            plan.AddRange(add);
            plan = plan.GroupBy(w => w.Id).Select(g => g.First()).ToList();
            Session["MyPlan"] = plan;
            return Json(new { ok = true, count = plan.Count });
        }

        [HttpPost]
        public ActionResult RemoveFromPlan(int id)
        {
            var plan = Session["MyPlan"] as List<Workout> ?? new List<Workout>();
            plan.RemoveAll(w => w.Id == id);
            Session["MyPlan"] = plan;
            return Json(new { ok = true, count = plan.Count });
        }

        public ActionResult MyPlan()
        {
            var plan = Session["MyPlan"] as List<Workout> ?? new List<Workout>();
            return PartialView("_MyPlan", plan);
        }
        #endregion
    }
}