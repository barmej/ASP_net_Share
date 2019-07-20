using Share.Business;
using Share.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Share.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RequestsController : Controller
    {
        // GET: Admin/Requests
        public ActionResult Index()
        {
            BorrowedToolRepository borrowRepo = new BorrowedToolRepository();
            var model = borrowRepo.GetAllBorrowedTools();

            return View(model);
        }

        public ActionResult Approve(int id)
        {
            BorrowedToolRepository borrowRepo = new BorrowedToolRepository();
            ToolRepository toolRepo = new ToolRepository();

            BorrowedTool borrowedTool = borrowRepo.GetBorrowedToolById(id);
            if (borrowedTool.tool_id.HasValue)
            {
                int toolId = borrowedTool.tool_id.Value;
                Tool tool = toolRepo.GetToolById(toolId);

                if (tool.quantity > 0)
                {
                    tool.quantity--;
                    borrowedTool.approved = true;
                    borrowRepo.Update(borrowedTool);
                    toolRepo.Update(tool);
                    TempData["SuccessMessage"] = "تمت العملية بنجاج";

                    return RedirectToAction("Index");
                }
            }
            TempData["ErrorMessage"] = "عذراً لا يمكن إكمال الطلب";
            return RedirectToAction("Index");
        }
    }
}