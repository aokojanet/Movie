using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActorsController : ControllerBase
	{
		private readonly MovieDb _Context;
		public ActorsController(MovieDb context)
		{
			_Context = context;
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(Actors actors)
		{
			if (!ModelState.IsValid)
			{
             return BadRequest(ModelState);
			}
			_Context.Add(actors);
			await _Context.SaveChangesAsync();


			return Ok("Create");
		}


	}
}
