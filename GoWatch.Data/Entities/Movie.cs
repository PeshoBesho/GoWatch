using GoWatch.Data.Entities.Abstractions;

namespace GoWatch.Data.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            Categories = new HashSet<Category>();
            Reviews = new HashSet<Review>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfCreation { get; set; }
        public string Director { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public string MovieUrl { get; set; }

    }
}
