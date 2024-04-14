using GoWatch.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.DTOs
{
    public class MovieDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfCreation { get; set; }
        public string Director { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public string MovieUrl { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
