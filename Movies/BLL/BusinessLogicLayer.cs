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

			listMovieDAL = dm.GetListFilmsByIdActor(idActor);
			if (listMovieDAL == null)
				return null;
			foreach (Movie m in listMovieDAL)
				listMovieDTO.Add(new MovieDTO(m.MovieID, m.Title, m.Releasedate, m.Voteaverage, m.Runtime, m.Posterpath));

			return listMovieDTO;
		}

		public static ICollection<CharacterDTO> GetCharacterByIdActorAndIdFilm(int actorId, int filmId)
		{
			ICollection<CharacterDTO> listCharacterDTO = new List<CharacterDTO>();
			ICollection<Character> listCharacterDAL = new List<Character>();
			DALManager manager = new DALManager();

			listCharacterDAL = manager.GetCharacterByIdActorAndIdFilm(actorId, filmId);
			foreach (Character c in listCharacterDAL)
			{
				var characterDTO = new CharacterDTO(c.CharacterID, c.Charactername);
				listCharacterDTO.Add(characterDTO);
			}

			return listCharacterDTO;
		}

		public static ICollection<MovieDTO> FindXFilmByPartialActorName(string name, int nbElm)
		{
			ICollection<MovieDTO> listFilmDTO = new List<MovieDTO>();
			ICollection<Movie> listMovieDAL = new List<Movie>();

			DALManager dm = new DALManager();

			listMovieDAL = dm.FindXFilmByPartialActorName(name, nbElm);
			if (listMovieDAL == null)
				return null;

			foreach (Movie m in listMovieDAL)
				listFilmDTO.Add(new MovieDTO(m.MovieID, m.Title, m.Releasedate, m.Voteaverage, m.Runtime, m.Posterpath));

			return listFilmDTO;
		}

		public static ICollection<LightMovieDTO> GetFavoriteFilms()
		{
			ICollection<LightMovieDTO> listLightMovieDTO = new List<LightMovieDTO>();
			ICollection<Movie> listMovieDAL = new List<Movie>();

			DALManager dm = new DALManager();

			listMovieDAL = dm.Get10FavoriteFilms();
			if (listMovieDAL == null)
				return null;

			foreach (Movie m in listMovieDAL)
				listLightMovieDTO.Add(new LightMovieDTO(m.MovieID, m.Title, m.Voteaverage));

			return listLightMovieDTO;
		}

		public static Boolean InsertCommentOnActorId(int actorId, CommentDTO commentDTO)
		{

			Comment comment = new Comment(commentDTO.Content, commentDTO.Rate, commentDTO.Date);

			DALManager dm = new DALManager();

			return dm.InsertCommentOnActorId(actorId, comment);
		}
	}
}
