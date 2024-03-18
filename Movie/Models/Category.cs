﻿namespace Movie.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Movie { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public ICollection<Movies>Movies { get; set; }
	}
}
