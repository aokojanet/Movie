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
		   var Movies = new Movies();
			{
				Movies.DateCreated = DateTime.Now;
				Movies.DateModified = DateTime.Now;
				Movies.DateOfRelease = DateTime.Now;
				Movies.IsAvailable = true;
				Movies.Name = Movies.Name;
			}
			if (movies == null)
			{
				return NotFound();
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
		[HttpGet]
		[Route("GetMovieActors")]
		public async Task<IActionResult> GetMovieActors(int id)
		{
			using (var context = _Context)
			{
				if (id == 0)
				{
					return BadRequest();
				}
				var Actor = await _Context.Actors.FirstOrDefaultAsync();
				if (Actor == null)
				{
					return NotFound();
				}
				return Ok();
			}
		}
		[HttpGet]
		[Route("GetActor")]
		public async Task<IActionResult> GetActor(int Id)
		{
			using (var context = _Context)
			{
				var Actors = await _Context.Actors
					  .Include(a => a.Movies)
					  .Where(a => a.Id == a.Id).ToListAsync();
				if (Actors == null)
				{
					return NotFound();
				}
				return Ok();

			}
		}
		[HttpGet]
		[Route("Details")]
		public async Task<IActionResult> Details(int id)
		{
			var Movies = _Context.Movies.FirstOrDefault(m => m.Id == id);
			if (Movies == null)
			{
				return NotFound();
			}
			return Ok(Movies);
		}
		[HttpGet]
		[Route("GetMoviesByActor")]
		public async Task<IActionResult> GetMoviesByActor(int id)

		{
			using (var context = _Context)
			{
				var actors = _Context.Actors
					.Include (a => a.Movies)
					.FirstOrDefault(a => a.Id == id);
				if (actors == null)
				{
					return NotFound();
				}
				return Ok(actors);
			}
		}
		[HttpGet]
		[Route("GetMovieRating")]
		public async Task<IActionResult> GetMovieRating(int movieId)
		{
			var movieRating = await _Context.Movies
		   .Where(m => m.Id == movieId).ToListAsync();

			if (movieRating == null)
			{
				return NotFound(); 
			}

			return Ok(movieRating);
		}

	}
}
