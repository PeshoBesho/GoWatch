using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.DTOs
{
    public class MovieCreateEditDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfCreation { get; set; }
        public string Director { get; set; }
        public string MovieUrl { get; set; }
        public List<int> CategoriesIds { get; set; }
        public string UserId { get; set; }

    }
}
