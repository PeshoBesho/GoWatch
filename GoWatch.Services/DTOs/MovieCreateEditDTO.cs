using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.DTOs
{
    public class MovieCreateEditDTO : MovieDTO
    {
        public List<int> CategoriesIds { get; set; }

    }
}
