using System;

namespace DTO
{
	public class MovieDTO
	{
		public int MovieID { get; set; }
		public string Title { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public float VoteAverage { get; set; }
		public int Runtime { get; set; }
		public string Posterpath { get; set; }

		public MovieDTO()
		{
			MovieID = 0;
			Title = "temp";
			ReleaseDate = new DateTime();
			VoteAverage = 0;
			Runtime = 0;
			Posterpath = null;
		}

		public MovieDTO(int id, string title, DateTime? rd, float va, int rt, string pp)
		{
			MovieID = id;
			Title = title;
			ReleaseDate = rd;
			VoteAverage = va;
			Runtime = rt;
			Posterpath = pp;
		}

		public override string ToString()
		{
			return "FilmDTO id:" + MovieID + " " + Title;
		}
	}
}
