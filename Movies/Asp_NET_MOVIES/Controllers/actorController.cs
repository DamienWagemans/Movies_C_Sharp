using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_NET_MOVIES.Controllers
{
    public class actorController : Controller
    {
		// GET: actor
		public ActionResult Index()
		{
			return View();
		}

		public string Welcome(string name, int ID = 1)
		{
			return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + ID);
		}
	}
}