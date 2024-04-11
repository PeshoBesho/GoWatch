using GoWatch.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.Abstractions
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetMovieAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task<List<MovieDTO>> GetMovieByTitleAsync(string title);
        Task AddMovieAsync(MovieDTO model);
        Task DeleteMovieByIdAsync(int id);
        Task UpdateMovieAsync(MovieDTO model);
    }
}
