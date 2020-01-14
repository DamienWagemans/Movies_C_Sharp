using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp_NET_MOVIES.Models;
using DTO;

namespace Asp_NET_MOVIES.Controllers
{
    public class commentController : Controller
    {
        // GET: comment
		[HttpGet]
        public ActionResult Index(int actorid = 0)
        {
			if(actorid == 0)
			{
				return RedirectToAction("Index", "actor", "Index");
			}

			ViewBag.ActorID = actorid;

			var WCF = new ServiceWCFMovies.Service1Client();
			var CommentsModel = new List<Comment>();
			ICollection<CommentDTO> CommentsDTO = new List<CommentDTO>();


			CommentsDTO = WCF.GetCommentByActorId(actorid);
			if (CommentsDTO != null)
			{
				foreach (CommentDTO c in CommentsDTO)
				{
					string image_path = ("/Rate_Stars/" + c.Rate +".png");
					CommentsModel.Add(new Comment(c.Content, c.Avatar, c.Date, image_path));
				}
			}
			else
			{
				return RedirectToAction("Index", "actor", "Index");
			}


			return View(CommentsModel);
		}

		[HttpPost]
		public ActionResult Index(int Input_ActorID, string Input_Avatar, string Input_Contenu, int Input_note)
		{
			ViewBag.ActorID = Input_ActorID;
			var WCF = new ServiceWCFMovies.Service1Client();
			if(WCF.InsertCommentOnActorId(Input_ActorID, new CommentDTO(Input_Contenu, Input_note, Input_Avatar))==false)
			{
				return RedirectToAction("Index", "actor","Index");
			}


			var CommentsModel = new List<Comment>();
			ICollection<CommentDTO> CommentsDTO = new List<CommentDTO>();
			CommentsDTO = WCF.GetCommentByActorId(Input_ActorID);
			if (CommentsDTO != null)
			{
				foreach (CommentDTO c in CommentsDTO)
				{
					string image_path = ("/Rate_Stars/" + c.Rate + ".png");
					CommentsModel.Add(new Comment(c.Content, c.Avatar, c.Date, image_path));
				}
			}


			return View(CommentsModel);

		}
	}
}