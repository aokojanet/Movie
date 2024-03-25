using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ControllerBase
	{ private readonly MovieDb _context;
		public RatingController (MovieDb context)
		{
			_context = context;
		}
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(Rating rating)
		{
			var Rating = new Rating();
			{
				Rating.DateCreated = DateTime.Now;
				Rating.User = rating.User;
			}
			_context.Add(Rating);
			await _context.SaveChangesAsync();
			return Ok(Rating);
		}
	}
}
