using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace WPF_App
{
	class Movies_ListViewModel
	{ 

		public ObservableCollection<MovieViewModel> Movies;
		private WCF_Movie_Services.Service1Client WCF;

		public Movies_ListViewModel ()
		{
			WCF = new WCF_Movie_Services.Service1Client();
			Movies = new ObservableCollection<MovieViewModel>();
		}

		public void Details_Actor_Movies(ActorViewModel a)
		{
			Movies.Clear();
			var ListMovies = WCF.GetMovieByIdActor(a.ActorId);
			foreach (MovieDTO mov in ListMovies)
			{
				var tmp = new MovieViewModel(mov, a.ActorId);
				Movies.Add(tmp);
			}
		}


		public void Add(MovieViewModel mov)
		{
			Movies.Add(mov);
		}
	}
}
