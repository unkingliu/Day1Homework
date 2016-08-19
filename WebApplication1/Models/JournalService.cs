using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Service
{
    public class JournalService : Repository<AccountBook>
    {
        private readonly IRepository<AccountBook> _journalRep;
        public JournalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _journalRep = new Repository<AccountBook>(unitOfWork);

        }
        public IEnumerable<JournalViewModel> Lookup()
        {
            var source = _journalRep.LookupAll();
            var result = source.Select(d => new JournalViewModel()
            {
                jType = (d.Categoryyy == 0 ? JournalType.支出 :
                                JournalType.收入),
                Amount = d.Amounttt,
                Date = d.Dateee,
                Remark = d.Remarkkk
            }).ToList();
            return result;
        }

        public void Add(JournalViewModel journal)
        {
            var result = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Categoryyy = (journal.jType == JournalType.支出 ? 0 :1),
                Amounttt = journal.Amount,
                Dateee = journal.Date,
                Remarkkk = journal.Remark
            };
            Add(result);
        }

        public void Add(AccountBook acctbook)
        {
            _journalRep.Create(acctbook);
        }

        public void Save()
        {
            _journalRep.Commit();
        }

        public IEnumerable<JournalViewModel>Query(Expression<Func<AccountBook, bool>> filter)
        {
            var source = _journalRep.Query(filter);
            var result = source.Select(d => new JournalViewModel()
            {
                jType = (d.Categoryyy == 0 ? JournalType.支出 :
                                JournalType.收入),
                Amount = d.Amounttt,
                Date = d.Dateee,
                Remark = d.Remarkkk
            }).ToList();
            return result;
        }
    }
}