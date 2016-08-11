using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class JournalController : Controller
    {
        private readonly Model1 _db = new Model1();
        // GET: Journal
        public ActionResult Index()
        {
            return View();
        }

        private JournalType getJType(int iCategory)
        {
            if (iCategory == 0)
            {
                return JournalType.支出;
            }
            else
            {
                return JournalType.收入;
            }
        }
        private ActionResult ChildAction_ListJ_old()
        { var Journal = new List<JournalViewModel>
            {
            new JournalViewModel {jType=JournalType.支出, Amount=100, Date = new DateTime(2016,8,01), Remark="早餐" },
            new JournalViewModel {jType=JournalType.收入, Amount=1200, Date = new DateTime(2016,8,02), Remark="零用金" },
            new JournalViewModel {jType=JournalType.支出, Amount=140, Date = new DateTime(2016,8,03), Remark="咖啡" },
            };
            return View(Journal);
        }
       
        [ChildActionOnly]
        public ActionResult ChildAction_ListJ()
        {
            var dbAccoutBook = _db.AccountBook.ToList();
            var Journal = (from d in _db.AccountBook
                            select new JournalViewModel()
                            {
                                jType = (d.Categoryyy==0? JournalType.支出:
                                JournalType.收入),
                                Amount = d.Amounttt,
                                Date = d.Dateee,
                                Remark = d.Remarkkk
                            }
                );
            return View(Journal);
        }
    }
}