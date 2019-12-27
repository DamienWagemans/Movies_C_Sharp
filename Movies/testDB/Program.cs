using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using DTO;

namespace testDB
{
	class Program
	{
		static void Main(string[] args)
		{
			#region AJOUT DE DONNEE
			//using (var manager = new DALManager())
			//{
			//	FilmParser.Load_X_film(manager, "C:/Users/damien/Desktop/movies_v2.txt", 50);
			//}
			//Console.WriteLine("FIN");
			//Console.ReadLine();
			#endregion


			//#region TEST AFFICHAGE COMPLET 5 PREMIERS FILMS
			//using (var manager = new DALManager())
			//{
			//	ICollection<Movie> Movies = manager.GetXFilms(5);
			//	foreach (Movie m in Movies)
			//	{
			//		Console.WriteLine(m);
			//	}
			//}
			//#endregion



			//#region Test BLL
			//Console.WriteLine("\n\nGetmoviebyidactor : id = 4826");
			//var list_movies = BusinessLogicLayer.GetMovieByIdActor(4826);
			//foreach (MovieDTO m in list_movies)
			//{
			//	Console.WriteLine(m);
			//}

			//Console.WriteLine("\n\nGet10MoviesbyPartialActorName (robin) :");
			//list_movies = BusinessLogicLayer.FindXMoviesByPartialActorName("Robin", 10);
			//foreach (MovieDTO m in list_movies)
			//{
			//	Console.WriteLine(m);
			//}

			//Console.WriteLine("\n\nGet10FavouriteMovies");
			//var list_light_movies = BusinessLogicLayer.GetFavoriteFilms();
			//foreach (LightMovieDTO m in list_light_movies)
			//{
			//	Console.WriteLine(m);
			//}

			//Console.WriteLine("\n\nGetCharacterByIDActor2andIdFilm11");
			//var list_character = BusinessLogicLayer.GetCharacterByIdActorAndIdFilm(2, 11);
			//foreach (CharacterDTO c in list_character)
			//{
			//	Console.WriteLine(c);
			//}

			//Console.WriteLine("\n\nGetActorbyID");
			//var actor = BusinessLogicLayer.GetActorById(3);
			//if (actor == null)
			//{
			//	Console.WriteLine("Pas trouvé");
			//}
			//else
			//{
			//	Console.WriteLine(actor);
			//}

			//Console.WriteLine("\n\nInsertion d'un commentaire ");
			//CommentDTO comm = new CommentDTO("Vraiment Null", 2, "Damien", DateTime.Now);
			//BusinessLogicLayer.InsertCommentOnActorId(2, comm);

			//Console.ReadLine();


			ICollection<CommentDTO> List_comm = BusinessLogicLayer.GetCommentByActorId(2);

			foreach (CommentDTO comm in List_comm)
			{
				Console.WriteLine(comm.ToString());
			}




			//#endregion


		}
	}
}
