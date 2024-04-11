using GoWatch.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
