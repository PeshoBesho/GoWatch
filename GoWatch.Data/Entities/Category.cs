using GoWatch.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category() 
        { 
            Movies = new HashSet<Movie>();
        }
        public string Name { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
