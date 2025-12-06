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
                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"),
                    $"Generate called: Part={vm.Part}, Level={vm.Level}, Goal={vm.Goal}, Gender={vm.Gender}, Age={vm.Age}\r\n");

                var q = _db.AsEnumerable();

                // 过滤条件
                if (vm.Part.HasValue)
                    q = q.Where(w => w.Part == vm.Part.Value);

                if (vm.Level.HasValue)
                    q = q.Where(w => w.Difficulty == vm.Level.Value.ToString());

                if (vm.Goal.HasValue)
                    q = GoalFilter(q, vm.Goal.Value);

                var generated = q.OrderBy(x => Guid.NewGuid()).Take(6).ToList();

                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"),
                    $"Found {generated.Count} items after filtering\r\n");

                return PartialView("_GeneratedList", generated);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(Server.MapPath("~/log.txt"),
                    $"Error in Generate: {ex.Message}\r\n{ex.StackTrace}\r\n");
                return Content("<div class='empty-state'><p>Error generating workout plan. Please try again.</p></div>");
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
        // 在现有方法后面添加

        [HttpPost]
        public ActionResult AddToWorkoutPlan(AddToPlanRequest request)
        {
            try
            {
                var plan = Session["MyPlan"] as List<Workout> ?? new List<Workout>();

                // 检查是否已存在
                var existing = plan.FirstOrDefault(w => w.Id == request.EquipmentId);
                if (existing != null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This exercise is already in your plan!"
                    });
                }

                // 从Workout种子数据获取完整信息
                var workout = _db.FirstOrDefault(w => w.Id == request.EquipmentId);
                if (workout == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Workout not found"
                    });
                }

                // 添加到用户计划
                plan.Add(new Workout
                {
                    Id = workout.Id,
                    Name = workout.Name,
                    Part = workout.Part,
                    Difficulty = workout.Difficulty,
                    ImgUrl = workout.ImgUrl,
                    Steps = workout.Steps,
                    Alternatives = workout.Alternatives
                });

                Session["MyPlan"] = plan;

                return Json(new
                {
                    success = true,
                    message = "Added to workout plan successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error: " + ex.Message
                });
            }
        }

        // 在文件末尾添加请求模型类
        public class AddToPlanRequest
        {
            public int EquipmentId { get; set; }
            public string EquipmentName { get; set; }
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

        // 添加这个方法到 GeneratorController
        [HttpPost]
        public ActionResult CheckInPlan(int id)
        {
            try
            {
                var plan = Session["MyPlan"] as List<Workout> ?? new List<Workout>();
                var isInPlan = plan.Any(w => w.Id == id);

                return Json(new
                {
                    success = true,
                    isInPlan = isInPlan,
                    message = isInPlan ? "Already in plan" : "Not in plan"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        #endregion
    }
}