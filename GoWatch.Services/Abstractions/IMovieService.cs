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
        Task<MovieCreateEditDTO> GetMovieByIdEditAsync(int id);
        Task<List<MovieDTO>> GetMovieByTitleAsync(string title);
        Task AddMovieAsync(MovieCreateEditDTO model);
        Task DeleteMovieByIdAsync(int id);
        Task UpdateMovieAsync(MovieCreateEditDTO model);
    }
}
