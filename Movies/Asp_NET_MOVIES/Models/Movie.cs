using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Asp_NET_MOVIES.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ReleaseDate { get; set; }
		public int Runtime { get; set; }
		public string Posterpath { get; set; }

		public Movie() { }
		public Movie(int id, string title, int runtime, string posterPath, DateTime? releaseDate)
		{
			Id = id;
			Title = title;
			ReleaseDate = String.Format("{0:dd/MM/yyyy}", releaseDate);
			Runtime = runtime;
			Posterpath = "https://image.tmdb.org/t/p/original" + posterPath;
		}
	}
}