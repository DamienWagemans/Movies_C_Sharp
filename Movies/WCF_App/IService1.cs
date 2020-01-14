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
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IService1
	{
		[OperationContract]
		ICollection<MovieDTO> GetMovieByIdActor(int idActor);

		[OperationContract]
		ICollection<LightMovieDTO> GetFavoriteFilms();

		[OperationContract]
		ICollection<CharacterDTO> GetCharacterByIdActorAndIdFilm(int actorId, int MovieId);

		[OperationContract]
		ICollection<MovieDTO> FindXMoviesByPartialActorName(string name, int nbElm);

		[OperationContract]
		Boolean InsertCommentOnActorId(int actorId, CommentDTO commentDTO);
		
		[OperationContract]
		FullActorDTO GetActorById(int id);

		[OperationContract]
		int GetCountActors();

		[OperationContract]
		ICollection<ActorDTO> GetXActorsFromY(int X, int Y);

		[OperationContract]
		ICollection<ActorDTO> GetXActorsByName(string name, int X);
		
		[OperationContract]
		ICollection<CommentDTO> GetCommentByActorId(int actorId);

		[OperationContract]
		int CountCommentsByActor(int actorId);

		[OperationContract]
		ICollection<CommentDTO> GetXCommentsFromYByActorId(int actorId, int X, int Y);

		[OperationContract]
		int getRateCommentbyActorID(int actorId);

		// TODO: Add your service operations here
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}
