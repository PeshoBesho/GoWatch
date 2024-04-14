using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoWatch.Data.Data;
using GoWatch.Data.Entities;
using GoWatch.Services.Abstractions;
using GoWatch.Services;
using GoWatch.Services.DTOs;
using GoWatch.Web.Models;
using GoWatch.Web.Utils;
using Microsoft.AspNetCore.Identity;

namespace GoWatch.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;

        public MoviesController(IMovieService movieService, ICategoryService categoryService, IWebHostEnvironment environment, UserManager<AppUser> userManager)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetMovieAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieByIdAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new MovieCreateEditViewModel();
            model.UserId = user.Id;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(model);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.Picture != null && movie.Picture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(movie.Picture, _environment.WebRootPath);
                    movie.PictureUrl = newFileName;
                }

                await _movieService.AddMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var user = await _userManager.GetUserAsync(User);
            var model = new MovieCreateEditViewModel();
            model.UserId = user.Id;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService
                .GetMovieByIdEditAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(new MovieCreateEditViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                PictureUrl = movie.PictureUrl,
                CategoriesIds = movie.CategoriesIds
            });
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel movie
            )
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (movie.Picture != null && movie.Picture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(movie.Picture, _environment.WebRootPath);
                    movie.PictureUrl = newFileName;
                }

                try
                {
                    await _movieService.UpdateMovieAsync(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RestaurantExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieByIdAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovieByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RestaurantExists(int id)
        {
            var restaurant = await _movieService.GetMovieByIdAsync(id);
            return restaurant != null;
        }
    }
}
