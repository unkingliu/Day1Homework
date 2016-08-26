using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Service;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class JournalWithServiceUseViewModelController : Controller
    {
        private readonly JournalService _journalSvc;
        // GET: JournalWithServiceUseViewModel
        public JournalWithServiceUseViewModelController()
        {
            var unitOfWork = new EFUnitOfWork();
            _journalSvc = new JournalService(unitOfWork);
            //_logSvc = new LogService(unitOfWork);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var journal = _journalSvc.Lookup();
            var mymodel_ = new JournalViewModel();
            mymodel_.jType = JournalType.支出;
            ViewBag.JournalList = journal;
            return View(mymodel_);
            //return PartialView("_JournalList", journal);
            //return RedirectToAction("JournalList", journal);
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: AccountBook/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "jType,Amount,Date,Remark")] JournalViewModel journal)
        {
            if (ModelState.IsValid)
            {
                var addGUID= _journalSvc.Add(journal);
                //_logSvc.Add(order.FirstName, order.LastName, order.Email, order.Id);
                _journalSvc.Save();
                //var journals = _journalSvc.Query(d => d.Amounttt == journal.Amount & d.Dateee == journal.Date & d.Remarkkk == journal.Remark);
                var journals = _journalSvc.Query(d=>d.Id ==addGUID);
                ////ViewBag.JournalList = journals;
                //return RedirectToAction("_JournalList", journals);
                return View("_JournalList", journals);
                //return View();

            }
            var result = new JournalViewModel()
            {
                Amount = journal.Amount,
                Date = journal.Date,
                Remark = journal.Remark,
                jType = journal.jType
            };
            return View(result);
        }
        public ActionResult JournalList()
        {
            var journal = _journalSvc.Lookup();
            return View("_JournalList", journal);
        }
        public ActionResult JournalListxx(IEnumerable<WebApplication1.ViewModels.JournalViewModel> journal)
        {
            return View("_JournalList", journal);
        }

    }
}