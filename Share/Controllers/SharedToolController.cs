using Microsoft.AspNet.Identity;
using Share.Business;
using Share.DAL;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Share.Controllers
{
    public class SharedToolController : Controller
    {

        // GET: SharedTool
        public ActionResult Index()
        {
            //List<SharedTool> SharedToolsList = new List<SharedTool>();

            //SharedToolsList.Add(new SharedTool("غسالة ملابس", "غسالة مستعملة بحالة جيدة تتسع لـ 10 كغ", 1, "/Images/washingMachine.jpg"));
            //SharedToolsList.Add(new SharedTool("دراجة هوائية", "دراجة هوائية كبيرة الحجم يمكن استخدامها وفق نظام استعارة ساعي", 3, "/Images/bicycle.png"));
            //SharedToolsList.Add(new SharedTool("تلفاز", " 32 inch تلفاز بشاشة مسطحة حجمها ", 0, "/Images/lcd.jpg"));
            //SharedToolsList.Add(new SharedTool("لابتوب", "جهاز كمبيوتر بمعالج Core i5", 5, "/Images/laptop.jpg"));
            ToolRepository toolRepository = new ToolRepository();
            List<Tool> tools = toolRepository.GetAllTools();

            return View(tools);

        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(FormCollection values)
        //{
        //    String toolName = values["ToolName"];
        //    String toolDescription = values["Description"];
        //    int quantity;
        //    int.TryParse(values["Quantity"], out quantity);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Quantity")]SharedTool sharedTool)
        {
            String toolName = sharedTool.ToolName;
            String toolDescription = sharedTool.Description;
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(SharedTool sharedTool, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                String toolName = sharedTool.ToolName;
                String toolDescription = sharedTool.Description;
                int quantity = sharedTool.Quantity;


                ToolRepository toolRepository = new ToolRepository();
                Tool tool = new Tool();
                tool.name = toolName;
                tool.description = toolDescription;
                tool.quantity = quantity;

                if (file != null)
                {
                   
                    String imageFileName = System.IO.Path.GetFileName(file.FileName);
                    String path = System.IO.Path.Combine(Server.MapPath("~/Images"), imageFileName);
                    file.SaveAs(path);
                    tool.image_url = "/Images/" + imageFileName;
                    toolRepository.Add(tool);

                    // /Images/imageName.jpg
                    // C://Users/admin/Share/Image/tv.jpg

                    return RedirectToAction("Index");
                }
            }
            return View(sharedTool);
        }

        [Authorize]
        public ActionResult RequestTool(int id)
        {
            BorrowedToolRepository borrowRepo = new BorrowedToolRepository();
            BorrowedTool borrowedTool = new BorrowedTool();
            String userid = User.Identity.GetUserId();
            UserRepository userRepo = new UserRepository();
            User shareUser = userRepo.GetUserByUserId(userid);
            borrowedTool.user_id = shareUser.id;
            borrowedTool.tool_id = id;
            borrowedTool.date = DateTime.Now;

            borrowRepo.Add(borrowedTool);
            return Content("تم إرسال الطلب بنجاح");
        }
    }
}