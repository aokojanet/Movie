namespace Movie.Models
{
	public class Rating
	{
		public int Id { get; set; }
		public string User { get; set; }
		public DateTime DateCreated { get; set; }	
		public Movies Movies { get; set; }
		public int MoviesId { get; set; }
	}
}
