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
        public string User { get; set; }
        public int MovieId { get; set; }
    }
}
