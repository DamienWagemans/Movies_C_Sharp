using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class LightMovieDTO
	{
		public int MovieId { get; set; }
		public string Title { get; set; }
		public float VoteAverage { get; set; }

		public LightMovieDTO()
		{
		}

		public LightMovieDTO(int id, string title, float va)
		{
			MovieId = id;
			Title = title;
			VoteAverage = va;
		}

		public override string ToString()
		{
			return "LightFilmDTO id:" + MovieId + " " + Title + "VA : " + VoteAverage;
		}
	}
}
