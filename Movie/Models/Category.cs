using System.Text.Json.Serialization;

namespace Movie.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		[JsonIgnore]
		public ICollection<Movies>? Movies { get; set; }
	}
}
