using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ControllerBase
	{
		private readonly MovieDb _context;
		public RatingController(MovieDb context)
		{
			_context = context;
		}
		[HttpPost]

		public async Task<IActionResult> RateMovie(int movieId, int ratingValue,int userId)
		{
			if (movieId <= 0 || ratingValue < 1 || ratingValue > 5)
			{
				return BadRequest("Invalid movie ID or rating value");
			}

			var movie = await _context.Movies.FindAsync(movieId);
			if (movie == null)
			{
				return NotFound("Movie not found");
			}

			var rating = new Rating
			{
				MoviesId = movieId,
				UsersId = userId,
				DateCreated = DateTime.Now,
			};
			await _context.Rating.AddAsync(rating);
			await _context.SaveChangesAsync();

			return Ok("Rating submitted successfully");
		}

	}
}
