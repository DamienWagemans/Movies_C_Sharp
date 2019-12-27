using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Test_WCF
{
	class Program
	{
		static void Main(string[] args)
		{
			var WCF = new ServiceReferenceFilm.Service1Client();

			Console.WriteLine("Getmoviebyidactor : id = 4826");
			var list_movies = WCF.GetMovieByIdActor(4826);
			foreach(MovieDTO m in list_movies)
			{
				Console.WriteLine(m);
			}

			Console.WriteLine("\n\nGet10MoviesbyPartialActorName (Robin) :");
			list_movies = WCF.FindXMoviesByPartialActorName("Robin", 10);
			foreach(MovieDTO m in list_movies)
			{
				Console.WriteLine(m);
			}
			

			Console.WriteLine("\n\nGet10FavouriteMovies");
			var list_light_movies = WCF.GetFavoriteFilms();
			foreach (LightMovieDTO m in list_light_movies)
			{
				Console.WriteLine(m);
			}

			Console.WriteLine("\n\nGetCharacterByIDActor2andIdFilm11");
			var list_character = WCF.GetCharacterByIdActorAndIdFilm(2, 11);
			foreach (CharacterDTO c in list_character)
			{ 
				Console.WriteLine(c);
			}

			Console.WriteLine("\n\nGetActorbyID2");
			var actor = WCF.GetActorById(2);
			if(actor == null)
			{
				Console.WriteLine("Pas trouvé");
			}
			else
			{
				Console.WriteLine(actor);
			}

			Console.ReadLine();

			Console.WriteLine("\n\nInsertion d'un commentaire ");
			CommentDTO comm = new CommentDTO("Vraiment Null", 2, "Damien", DateTime.Now);
			WCF.InsertCommentOnActorId(2, comm) ;

			Console.ReadLine();


		}
	}
}
