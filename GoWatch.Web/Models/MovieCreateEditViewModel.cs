using GoWatch.Services.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GoWatch.Web.Models
{
    public class MovieCreateEditViewModel : MovieCreateEditDTO
    {
        public IFormFile Picture { get; set; }
    }
}
