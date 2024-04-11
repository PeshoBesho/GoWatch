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
        public async Task AddMovieAsync(MovieDTO model)
        {
            var movie = _mapper.Map<Movie>(model);
            await _movieRepository.AddAsync(movie);
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            await _movieRepository.DeleteByIdAsync(id);

        }

        public async Task<List<MovieDTO>> GetMovieAsync()
        {
            var movies = (await _movieRepository.GetAllAsync()).ToList();
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<List<MovieDTO>> GetMovieByTitleAsync(string title)
        {
            var movies = (await _movieRepository.GetAsync(item => item.Name == title)).ToList();
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        public async Task UpdateMovieAsync(MovieDTO model)
        {
            var movie = _mapper.Map<Movie>(model);
            await _movieRepository.UpdateAsync(movie);
        }
    }
}
