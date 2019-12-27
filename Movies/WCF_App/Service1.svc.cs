using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTO;
using BLL;

namespace WCF_App
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{
		public int CountCommentsByActor(int actorId)
		{
			return BusinessLogicLayer.CountCommentsByActor(actorId);
		}

		public ICollection<MovieDTO> FindXMoviesByPartialActorName(string name, int nbElm)
		{
			return BusinessLogicLayer.FindXMoviesByPartialActorName(name,nbElm);
		}

		public FullActorDTO GetActorById(int id)
		{
			return BusinessLogicLayer.GetActorById(id);
		}

		public ICollection<CharacterDTO> GetCharacterByIdActorAndIdFilm(int actorId, int MovieId)
		{
			return BusinessLogicLayer.GetCharacterByIdActorAndIdFilm (actorId,MovieId);
		}

		public ICollection<CommentDTO> GetCommentByActorId(int actorId)
		{
			return BusinessLogicLayer.GetCommentByActorId(actorId);
		}

		public int GetCountActors()
		{
			return BusinessLogicLayer.GetCountActors();
		}

		public ICollection<LightMovieDTO> GetFavoriteFilms()
		{
			return BusinessLogicLayer.GetFavoriteFilms();
		}

		public ICollection<MovieDTO> GetMovieByIdActor(int idActor)
		{
			return (List<MovieDTO>)BusinessLogicLayer.GetMovieByIdActor(idActor);
		}

		public ICollection<ActorDTO> GetXActorsByName(string name, int X)
		{
			return BusinessLogicLayer.GetXActorsByName(name, X);
		}

		public ICollection<ActorDTO> GetXActorsFromY(int X, int Y)
		{
			return BusinessLogicLayer.GetXActorsFromY(X, Y);
		}

		public ICollection<CommentDTO> GetXCommentsFromYByActorId(int actorId, int X, int Y)
		{
			return BusinessLogicLayer.GetXCommentsFromYByActorId(actorId, X, Y);
		}

		public void InsertCommentOnActorId(int actorId, CommentDTO commentDTO)
		{
			BusinessLogicLayer.InsertCommentOnActorId (actorId, commentDTO);
		}
	}
}
