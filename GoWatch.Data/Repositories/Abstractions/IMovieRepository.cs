using GoWatch.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Repositories.Abstractions
{
    public interface IMovieRepository : ICrudRepository<Movie>
    {
        public Task UpdateMovie(Movie movie, List<Category> categories);
    }
}
