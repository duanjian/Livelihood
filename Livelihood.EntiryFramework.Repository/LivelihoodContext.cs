using Livelihood.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livelihood.EntiryFramework.Repository
{
    public class LivelihoodContext : DbContext
    {
        public LivelihoodContext()
            : base("name=Livelihood")
        {

        }

        public virtual IDbSet<Todo> Tasks { get; set; }

        
    }
}
