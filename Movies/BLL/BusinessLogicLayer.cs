using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;


namespace BLL
{
    public class BusinessLogicLayer
    {
		public static ICollection<MovieDTO> GetMovieByIdActor(int idActor)
		{
			ICollection<MovieDTO> listMovieDTO = new List<MovieDTO>();
			ICollection<Movie> listMovieDAL = new List<Movie>();
			DALManager dm = new DALManager();

			//recherche de tout les movies
			listMovieDAL = dm.GetListMoviesByIdActor(idActor);
			if (listMovieDAL == null)
				return null;
			//conversion movieDAL en movieDTO
			foreach (Movie m in listMovieDAL)
				listMovieDTO.Add(new MovieDTO(m.MovieID, m.Title, m.Releasedate, m.Voteaverage, m.Runtime, m.Posterpath));

			return listMovieDTO;
		}

		public static ICollection<CharacterDTO> GetCharacterByIdActorAndIdFilm(int actorId, int MovieId)
		{
			ICollection<CharacterDTO> listCharacterDTO = new List<CharacterDTO>();
			ICollection<Character> listCharacterDAL = new List<Character>();
			DALManager manager = new DALManager();
			
			//rech de tout les Characters
			listCharacterDAL = manager.GetCharacterByIdActorAndIdMovie(actorId, MovieId);
			
			//conversion DAL vers DTO
			foreach (Character c in listCharacterDAL)
			{
				var characterDTO = new CharacterDTO(c.CharacterID, c.Charactername);
				listCharacterDTO.Add(characterDTO);
			}

			return listCharacterDTO;
		}

		public static ICollection<MovieDTO> FindXMoviesByPartialActorName(string name, int nbElm)
		{
			ICollection<MovieDTO> listFilmDTO = new List<MovieDTO>();
			ICollection<Movie> listMovieDAL = new List<Movie>();

			DALManager dm = new DALManager();

			listMovieDAL = dm.FindXMoviesByPartialActorName(name, nbElm);
			if (listMovieDAL == null)
				return null;

			foreach (Movie m in listMovieDAL)
				listFilmDTO.Add(new MovieDTO(m.MovieID, m.Title, m.Releasedate, m.Voteaverage, m.Runtime, m.Posterpath));

			return listFilmDTO;
		}

		public static int GetCountActors()
		{
			var dm = new DALManager();
			
			return dm.GetCountActors();
		}

		public static ICollection<ActorDTO> GetXActorsFromY(int X, int Y)
		{
			DALManager manager = new DALManager();

			var Actors = manager.GetXActorsFromY(X, Y);
			var ActorsDTO = new List<ActorDTO>();
			foreach (Actor a in Actors)
				ActorsDTO.Add(new ActorDTO(a.ActorID, a.Name, a.Firstname));
			return ActorsDTO;
		}

		public static ICollection<ActorDTO> GetXActorsByName(string name, int X)
		{
			DALManager manager = new DALManager();
			var Actors = manager.GetXActorsByName(name, X);
			var ActorsDTO = new List<ActorDTO>();
			foreach(Actor a in Actors)
			{
				ActorsDTO.Add(new ActorDTO(a.ActorID, a.Name, a.Firstname));
			}
			return ActorsDTO;
		}

		public static ICollection<LightMovieDTO> GetFavoriteFilms()
		{
			ICollection<LightMovieDTO> listLightMovieDTO = new List<LightMovieDTO>();
			ICollection<Movie> listMovieDAL = new List<Movie>();

			DALManager dm = new DALManager();

			listMovieDAL = dm.Get10FavoriteMovies();
			if (listMovieDAL == null)
				return null;

			foreach (Movie m in listMovieDAL)
				listLightMovieDTO.Add(new LightMovieDTO(m.MovieID, m.Title, m.Voteaverage));

			return listLightMovieDTO;
		}

		public static Boolean InsertCommentOnActorId(int actorId, CommentDTO commentDTO)
		{

			Comment comment = new Comment(commentDTO.Content, commentDTO.Rate, commentDTO.Avatar, commentDTO.Date);

			DALManager dm = new DALManager();

			return dm.InsertCommentOnActorId(actorId, comment);
		}
		public static ICollection<CommentDTO> GetCommentByActorId(int actorId)
		{
			DALManager DM = new DALManager();
			var listCommentDTO = new List<CommentDTO>();
			var listComment = DM.GetCommentsByActorId(actorId);
			foreach (Comment c in listComment)
				listCommentDTO.Add(new CommentDTO(c.Content, c.Rate, c.Avatar,c.Date));
			return listCommentDTO;
		}


		public static int CountCommentsByActor(int actorId)
		{
			DALManager DM = new DALManager();
			var number = DM.CountCommentsByActor(actorId);
			return number;
		}

		public static ICollection<CommentDTO> GetXCommentsFromYByActorId(int actorId, int X, int Y)
		{
			DALManager DM = new DALManager();
			var listCommentDTO = new List<CommentDTO>();
			var listComment = DM.GetXCommentsFromYByActorId(actorId, X, Y);
			foreach (Comment c in listComment)
				listCommentDTO.Add(new CommentDTO(c.Content, c.Rate, c.Avatar, c.Date));
			return listCommentDTO;
		}

		public static FullActorDTO GetActorById(int id)
		{
			FullActorDTO ActorDTO = new FullActorDTO();
			Actor ActorDAL = new Actor();

			DALManager dm = new DALManager();

			ActorDAL = dm.GetActorById(id);

			if(ActorDAL == null)
			{
				return null;
			}
			else
			{
				ActorDTO.ActorId = ActorDAL.ActorID;
				ActorDTO.Name = ActorDAL.Name;
				ActorDTO.Firstname = ActorDAL.Firstname;
				
				foreach(Movie m in ActorDAL.Movies)
				{
					ActorDTO.Movies.Add(new LightMovieDTO(m.MovieID, m.Title, m.Voteaverage));
				}
				return ActorDTO;
			}

		}
	}
}
