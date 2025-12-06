using JoyRiseFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace JoyRiseFitness.Controllers
{
    public class EquipmentController : Controller
    {
        private const int PageSize = 6;
        private static readonly List<Equipment> _db = new List<Equipment>
        {
           new Equipment{Id=1, Name="Barbell Bench Press",
    Part=MusclePart.Chest, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1661286749098-fd5d4678e320?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Compound move for bigger chest."},

new Equipment{Id=2, Name="Dumbbell Shoulder Press",
    Part=MusclePart.Shoulders, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1664476845281-a29067796a2f?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Build rounded delts."},

new Equipment{Id=3, Name="Lat Pull-down",
    Part=MusclePart.Back, Difficulty="Beginner",
     ImgUrl = "https://plus.unsplash.com/premium_photo-1672862926934-d9f7e3f33632?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Vertical pull for V-back."},

new Equipment{Id=4, Name="Leg Press",
    Part=MusclePart.Legs, Difficulty="Beginner",
    ImgUrl="https://images.unsplash.com/photo-1571019613723-c7e5b75bd4c6?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Safe machine squat."},

new Equipment{Id=5, Name="Biceps Curl",
    Part=MusclePart.Arms, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1661265933107-85a5dbd815af?q=80&w=1118&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Constant tension for arms."},

new Equipment{Id=6, Name="Plank",
    Part=MusclePart.Core, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1672352100050-65cb2ee4d818?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Core activation & spine safety."},

new Equipment{Id=7, Name="Smith Machine Squat",
    Part=MusclePart.Legs, Difficulty="Intermediate",
    ImgUrl="https://images.unsplash.com/photo-1653276527526-f902a569d3c9?q=80&w=764&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Guided heavy squat."},

new Equipment{Id=8, Name="Cable Wood-chop",
    Part=MusclePart.Core, Difficulty="Intermediate",
    ImgUrl="https://plus.unsplash.com/premium_photo-1663047570926-2fed4638b79a?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Rotational core power."},

new Equipment{Id=9, Name="Hip Thrust",
    Part=MusclePart.Legs, Difficulty="Intermediate",
    ImgUrl="https://plus.unsplash.com/premium_photo-1661407412468-dc5059bb4098?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Z2x1dGUlMjBicmlkZ2V8ZW58MHx8MHx8fDA%3D",
    ShortDesc="Best glute builder."},

new Equipment{Id=10, Name="Pec Deck Fly",
    Part=MusclePart.Chest, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1663076314882-d16c23ffe2e8?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjh8fCVFNSU4MSVBNSVFOCVCQSVBQnxlbnwwfHwwfHx8MA%3D%3D",
    ShortDesc="Isolate chest fibers."},

new Equipment{Id=11, Name="Seated Row",
    Part=MusclePart.Back, Difficulty="Beginner",
    ImgUrl="https://plus.unsplash.com/premium_photo-1664299683145-d5ae24790f8e?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    ShortDesc="Horizontal pull for thickness."},

new Equipment{Id=12, Name="Triceps Push-down",
    Part=MusclePart.Arms, Difficulty="Beginner",
    ImgUrl="https://images.unsplash.com/flagged/photo-1597786776169-17549989c2bf?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8VHJpY2VwcyUyMFB1c2gtZG93bnxlbnwwfHwwfHx8MA%3D%3D",
    ShortDesc="Isolate triceps with cable."}
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
        // 在 EquipmentController 的 Detail 方法中，确保返回正确的类型
        // 修改 EquipmentController 中的 Detail 方法
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var item = _db.FirstOrDefault(e => e.Id == id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }

            // 只返回 Equipment 类型，不尝试转换
            return View(item);
        }
    }
}