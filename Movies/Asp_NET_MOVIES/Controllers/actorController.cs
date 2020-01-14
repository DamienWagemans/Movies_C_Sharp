using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp_NET_MOVIES.Models;
using DTO;

namespace Asp_NET_MOVIES.Controllers
{
    public class actorController : Controller
    {
		// GET: actor
		public ActionResult Index(string chgm_page=null, int page_en_cours = 1)
		{
			var WCF = new ServiceWCFMovies.Service1Client();
			var ActorsModel = new List<Actor>();
			ICollection<ActorDTO> ActorsDTO = new List<ActorDTO>();
			
			int nombre_de_page = WCF.GetCountActors()/10;

			if(page_en_cours < 1 || page_en_cours > nombre_de_page)
			{
				return RedirectToAction("Index", "actor", "Index");
			}

			if (chgm_page == "precedent")
			{
				if (page_en_cours > 1)
				{
					page_en_cours--;
				}
			}
			if (chgm_page == "suivant")
			{
				if (page_en_cours < nombre_de_page)
				{
					page_en_cours++;
				}
			}

			ViewBag.page_en_cours = page_en_cours;

			ActorsDTO = WCF.GetXActorsFromY(10, (page_en_cours - 1) * 10);
			ViewBag.Pagination = (page_en_cours + "/" + nombre_de_page);
			
			


			foreach (ActorDTO a in ActorsDTO)
			{
				string image_path = ("/Rate_Stars/"+ WCF.getRateCommentbyActorID(a.ActorId)+".png");
				ActorsModel.Add(new Actor(a.ActorId, a.Firstname, a.Name, image_path));
			}

			return View(ActorsModel);
		}


	}
}