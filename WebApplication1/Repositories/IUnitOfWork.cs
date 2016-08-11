using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        void Save();
    }
}
