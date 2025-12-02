using System.Web.Mvc;

namespace JoyRiseFitness.Controllers
{
    public class HomeController : Controller
    {
        // 已有的Index方法
        public ActionResult Index()
        {
            ViewBag.Current = 37;
            ViewBag.Max = 80;
            return View();
        }

        // 添加Contact方法
        public ActionResult Contact()
        {
            return View();
        }

        // 可选的：处理表单提交的方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // 这里可以添加发送邮件的逻辑
                TempData["SuccessMessage"] = "Thank you for your message! We'll get back to you soon.";
                return RedirectToAction("Contact");
            }
            return View(model);
        }
    }

    // 联系表单模型（可选）
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}