using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Livelihood.Model
{
    public class Todo
    {
        public int TodoId { get; set; }

        [Required]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public int Status { get; set; }

        public TaskLevel TaskLevel { get; set; }

        public DateTime CreationTime { get; set; }

        public int CreationId { get; set; }

        public bool IsDeleted { get; set; }

        public string Remark { get; set; }
    }
}
