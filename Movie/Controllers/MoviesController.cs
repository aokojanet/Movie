using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MovieDb _Context;
		public MoviesController(MovieDb context)
		{
			_Context = context;
		}
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(Movies movies)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			using (var context = _Context)
			{
				var Movies = await _Context.Movies.FirstOrDefaultAsync();
			}
			_Context.Add(movies);
			await _Context.SaveChangesAsync();
			return Ok();
		}

		[HttpGet]
		[Route("GetMovieTitle")]
		public async Task<Movies> GetMovieTitle(string tittle)
		{
			using (var context = _Context)
			{
				var Movies = await context.Movies.FirstOrDefaultAsync(m => m.Tittle == tittle);
				return Movies;
			}

		}
		[HttpGet]
		[Route("GetReleasedMovies")]
		public async Task<IActionResult> GetReleasedMovies()
		{
			using (var context = _Context)
			{
				var today = DateTime.Now;
				var ReleasedMovies = _Context.Movies
					.Where(m => m.DateOfRelease < today).ToList();
				return Ok(ReleasedMovies);
			}
		}
		[HttpGet]
		[Route("GetAvailableMovies")]
		public async Task<IEnumerable<Movies>> GetAvailableMovies()
		{
			using (var context = _Context)
			{
				var AvailableMovies = _Context.Movies.Where(m => m.IsAvailable).ToList();
				return AvailableMovies;
			}
		}
		[HttpGet]
		[Route("GetByCategory")]
		public async Task<IActionResult> GetByCategory(int id)
		{
			using (var context = _Context)
			{
				var Movies = _Context.Movies.Where(m => m.Category.Id == id).ToList();
				return Ok(Movies);

			}
		}
		[HttpPost]
		[Route("UpDateMovies")]
		public async Task<IActionResult> UpDateMovies(int id)
		{
			using (var context = _Context)
			{
				if (id == 0)
				{
					return BadRequest();
				}

				var movie = await _Context.Movies.FirstOrDefaultAsync(m => m.Id == id);

				if (movie == null)
				{
					return NotFound();
				}

				
				_Context.Update(movie);
				await _Context.SaveChangesAsync();

				return Ok();
			}
		}
		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(int id)
		{
			var movie = await _Context.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound($"Movie not found with id: {id}"); 
			}

			_Context.Remove(movie);
			await _Context.SaveChangesAsync();
			return Ok();
		}

	}
}
