using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livelihood.Model.Entity
{
    public class TodoCategory
    {
        public int Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTaime { get; set; }

        public int CreationId { get; set; }

        public bool IsDeleted { get; set; }

        public string Remark { get; set; }
    }
}
