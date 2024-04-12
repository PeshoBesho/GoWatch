using GoWatch.Data.Entities.Abstractions;

namespace GoWatch.Data.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            Categories = new HashSet<Category>();
        }
        public virtual AppUser? User { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfCreation { get; set; }
        public string Director { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public string MovieUrl { get; set; }
        public string UserId { get; set; }


    }
}
