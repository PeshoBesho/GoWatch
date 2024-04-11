using GoWatch.Data.Data;
using GoWatch.Data.Entities;
using GoWatch.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Repositories
{
    public class MovieRepository : CrudRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateMovie(Movie movie, List<Category> categories)
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
            _context.Movies.Attach(movie);

            if (!_context.Entry(movie).Collection(r => r.Categories).IsLoaded)
            {
                await _context.Entry(movie).Collection(r => r.Categories).LoadAsync();
            }
            movie.Categories = categories;

            await UpdateAsync(movie);
        }
    }
}
