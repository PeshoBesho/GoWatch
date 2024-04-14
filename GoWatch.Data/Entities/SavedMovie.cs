using GoWatch.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Entities
{
    public class SavedMovie : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
