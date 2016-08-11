using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var journal = _journalSvc.Lookup();
            return View(journal);
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
        public ActionResult Create([Bind(Include = "Amount,Date,Remark,jType")] JournalViewModel journal)
        {
            if (ModelState.IsValid)
            {
                _journalSvc.Add(journal);
                //_logSvc.Add(order.FirstName, order.LastName, order.Email, order.Id);
                _journalSvc.Save();

                return RedirectToAction("Index");
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
    }
}