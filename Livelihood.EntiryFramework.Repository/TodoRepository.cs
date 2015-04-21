using Livelihood.IRepository;
using Livelihood.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livelihood.EntiryFramework.Repository
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {       
        public TodoRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
