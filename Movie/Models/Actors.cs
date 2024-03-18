namespace Movie.Models
{
	public class Actors
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public bool IsAlive { get; set; }
		public ICollection<Movies> Movies { get; set; }
	}
}
