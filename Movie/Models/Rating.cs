namespace Movie.Models
{
	public class Rating
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public Movies? Movies { get; set; }
		public User? User { get; set; }
		public int MoviesId { get; set; }
		public int UsersId { get; set;}

	}
}
