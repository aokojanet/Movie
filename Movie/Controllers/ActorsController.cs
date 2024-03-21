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
			var Actors = new Actors();
			{
				Actors.Name = actors.Name;
				Actors.DateModified = DateTime.UtcNow;
				Actors.DateCreated = DateTime.UtcNow;
			}
			_Context.Add(actors);
			await _Context.SaveChangesAsync();


			return Ok();
		}
		[HttpDelete]
		[Route("DeleteActors")]
		public async Task<IActionResult> DeleteActors(int id)
		{
			var Actors = _Context.Actors.FirstOrDefault(a => a.Id == id);
			if (Actors == null)
			{
				return BadRequest();
			}
			_Context.Remove(Actors);
			await _Context.SaveChangesAsync();
			return Ok();
		}
		[HttpPost]
		[Route("Update")]
		public async Task<IActionResult> update(int id)
		{
			using (var context = _Context)
			{
				if (id == 0)
				{
					return NotFound();
				}
				var actor = _Context.Actors.FirstOrDefault(a => a.Id == id);	
				if (actor == null)
				{
					return BadRequest();
				}
				_Context.Update(actor);
				await _Context.SaveChangesAsync();
				return Ok();
			}
		}
		[HttpGet]
		[Route("Details")]
		public async Task<IActionResult> Details(int id)
		{
			var actors = _Context.Actors.FirstOrDefault(a => a.Id == id);
			if (actors == null)
			{
				return BadRequest();
			}
			return Ok();
		}
	}
	
}
