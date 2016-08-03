using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class JournalController : Controller
    {
        // GET: Journal
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ChildAction_ListJ()
        { var Journal = new List<JournalViewModel>
            {
            new JournalViewModel {jType=JournalType.支出, Amount=100, Date = new DateTime(2016,8,01), Remark="早餐" },
            new JournalViewModel {jType=JournalType.收入, Amount=1200, Date = new DateTime(2016,8,02), Remark="零用金" },
            new JournalViewModel {jType=JournalType.支出, Amount=140, Date = new DateTime(2016,8,03), Remark="咖啡" },
            };
            return View(Journal);
        }
    }
}