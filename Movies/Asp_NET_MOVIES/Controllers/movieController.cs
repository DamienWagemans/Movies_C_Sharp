using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp_NET_MOVIES.Models;
using DTO;

namespace Asp_NET_MOVIES.Controllers
{
    public class movieController : Controller
    {
        // GET: movie
        public ActionResult Index(int actorid = 0)
        {
			var WCF = new ServiceWCFMovies.Service1Client();
			var MoviesModel = new List<Movie>();
			ICollection<MovieDTO> MoviesDTO = new List<MovieDTO>();


			MoviesDTO = WCF.GetMovieByIdActor(actorid);
			if(MoviesDTO != null)
			{
				foreach (MovieDTO m in MoviesDTO)
				{
					MoviesModel.Add(new Movie(m.MovieID, m.Title, m.Runtime, m.Posterpath, m.ReleaseDate));
				}
			}
			else
			{
				return RedirectToAction("Index", "actor", "Index");
			}


			return View(MoviesModel);
		}
    }
}