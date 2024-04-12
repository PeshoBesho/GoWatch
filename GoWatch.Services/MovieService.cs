using AutoMapper;
using GoWatch.Data.Entities;
using GoWatch.Data.Repositories.Abstractions;
using GoWatch.Services.Abstractions;
using GoWatch.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICrudRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, ICrudRepository<Category> categoryRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task AddMovieAsync(MovieCreateEditDTO model)
        {
            var Movie = _mapper.Map<Movie>(model);

            var categories = model.CategoriesIds
                .Select(item => _categoryRepository.GetByIdAsync(item).Result)
                .ToList();
            Movie.Categories = categories;
            await _movieRepository.AddAsync(Movie);
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            await _movieRepository.DeleteByIdAsync(id);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var Movie = await _movieRepository
                .GetByIdAsync(id);

            return _mapper.Map<MovieDTO>(Movie);
        }

        public async Task<MovieCreateEditDTO> GetMovieByIdEditAsync(int id)
        {
            var Movie = await _movieRepository
                .GetByIdAsync(id);
            return _mapper.Map<MovieCreateEditDTO>(Movie);
        }
        public async Task<List<MovieDTO>> GetMovieByTitleAsync(string name)
        {
            var Movies = await _movieRepository.GetAsync(item => item.Name == name);
            return _mapper.Map<List<MovieDTO>>(Movies);
        }

        public async Task<List<MovieDTO>> GetMovieAsync()
        {
            var Movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<List<MovieDTO>>(Movies);
        }

        public async Task UpdateMovieAsync(MovieCreateEditDTO model)
        {
            var Movie = _mapper.Map<Movie>(model);

            var categories = model.CategoriesIds
                .Select(item => _categoryRepository.GetByIdAsync(item).Result)
                .ToList();

            await _movieRepository.UpdateMovie(Movie, categories);
        }
    }
}
