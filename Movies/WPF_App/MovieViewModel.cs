using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace WPF_App
{
	class MovieViewModel
	{
		private  MovieDTO Movie { get; set; }


		public MovieViewModel() 
		{
			Movie = new MovieDTO();
		}

		public MovieViewModel(MovieDTO m, int actorId)
		{
			Movie = m;
			ActorId = actorId;
		}

		public string Title
		{
			get { return Movie.Title; }
			set { Movie.Title = value; }
		}

		public string ReleaseDate
		{
			get { return String.Format("{0:dd/MM/yyyy}", Movie.ReleaseDate); }
			set { Movie.ReleaseDate = DateTime.Parse(value); }
		}

		public float VoteAverage
		{
			get { return Movie.VoteAverage; }
			set { Movie.VoteAverage = value; }
		}
		public string Runtime
		{
			get
			{
				TimeSpan ts = TimeSpan.FromMinutes(Movie.Runtime);
				return ts.ToString(@"h\Hmm"); ;
			}
			set { Movie.Runtime = Convert.ToInt32(value); }
		}
		public string Posterpath
		{
			get { return Movie.Posterpath; }
			set { Movie.Posterpath = value; }
		}

		public int ActorId { get; private set; }
		public string CharactersList
		{
			get
			{
				var WCF = new WCF_Movie_Services.Service1Client();
				var Characters = WCF.GetCharacterByIdActorAndIdFilm(ActorId, Movie.MovieID);
				string character_String = "";
				foreach (CharacterDTO c in Characters)
					character_String = character_String +  c.Name + " / ";
				return character_String;
			}
			set { CharactersList = value; }
		}
	}
}
