using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly MovieDb _Context;
		public CategoryController(MovieDb context)
		{
			_Context = context;
		}
		[HttpGet]
		[Route("GetAllCategory")]
		public async Task<IEnumerable<Category>> GetAllCategory(MovieDb movieDb)
		{
			using (var context = _Context) {
				var Category = await _Context.Category.ToListAsync();

				return Category;
			}
		}
		[HttpGet]
		[Route("GetCategoryName")]
		public async Task<IActionResult> GetCategoryName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return BadRequest("Please provide a category name.");
			}

			var category = await _Context.Category
				.Where(c => c.Name.Equals(name))
				.FirstOrDefaultAsync();

			//var category = await _Context.Category
			//.Where(c => c.Name.Contains(name))
			//.ToListAsync();

			if (category == null)
			{
				return NotFound("Category not found.");
			}

			return Ok(category); 
		}
	}

}

