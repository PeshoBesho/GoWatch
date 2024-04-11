using GoWatch.Data.Entities;
using GoWatch.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.Abstractions
{
    public interface ICategoryService
    {
        //change entity to DTO's
        Task<List<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<List<CategoryDTO>> GetCategoryByTitleAsync(string title);
        Task AddCategoryAsync(CategoryDTO category);
        Task DeleteCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(CategoryDTO category);
    }
}
