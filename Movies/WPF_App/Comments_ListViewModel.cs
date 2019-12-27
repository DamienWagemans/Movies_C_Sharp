using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace WPF_App
{
	class Comments_ListViewModel
	{
		public ObservableCollection<CommentViewModel> Comments;
		private WCF_Movie_Services.Service1Client WCF;

		private int ActorID { get; set; }
		private int Moyenne { get; set; }
		private string Name { get; set; }
		private string Firstname { get; set; }

		public Comments_ListViewModel(int actorID)
		{
			Comments = new ObservableCollection<CommentViewModel>();
			WCF = new WCF_Movie_Services.Service1Client();
			ActorID = actorID;
		}


		public void refresh_comments(int X, int Y)
		{
			Comments.Clear();
			Moyenne = 0;

			ICollection<CommentDTO> CommentsDTO_List = WCF.GetXCommentsFromYByActorId(ActorID, X, Y);

			var actor = WCF.GetActorById(ActorID);
			Name = actor.Name;
			Firstname = actor.Firstname;

			if (CommentsDTO_List.Count != 0)
			{
				foreach (CommentDTO c in CommentsDTO_List)
				{
					Comments.Add(new CommentViewModel(c));
					Moyenne += c.Rate;
				}
			}

		}

		public string get_Name_Moyenne()
		{
			if(Comments.Count != 0)
			{
				string retour = Firstname + " " + Name + "  " + Moyenne / Comments.Count + "(" + Comments.Count + ")";
				return retour;
			}
			else
			{
				string retour = Firstname + " " + Name + " (Aucune commentaire)";
				return retour;
			}
		}

		public void insert_comment(CommentDTO comm, int actor_ID)
		{
			WCF.InsertCommentOnActorId(actor_ID, comm);
		}

	}
}
