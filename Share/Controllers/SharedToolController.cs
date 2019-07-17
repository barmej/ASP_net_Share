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
        public ActionResult Create(SharedTool sharedTool)
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

                return RedirectToAction("Index");
            }
            else 
                return View(sharedTool);
        }
        public ActionResult RequestTool()
        {
            return Content("");
        }
    }
}