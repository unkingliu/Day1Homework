using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class EFUnitOfWork :IUnitOfWork
    {
        public DbContext Context { get; set; }
        public EFUnitOfWork()
        {
            Context = new Model1();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}