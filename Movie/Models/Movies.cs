namespace Movie.Models
{
	public class Movies
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfRelease { get; set; }
		public DateTime DateModified { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsAvailable { get; set; }
		public string Tittle { get; set; }
		public Category Category { get; set; }
		public ICollection<Actors> Actors { get; set; }
		public Rating Rating { get; set; }

	}
}
