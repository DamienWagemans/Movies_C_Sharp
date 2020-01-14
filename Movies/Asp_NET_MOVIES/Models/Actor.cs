using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_NET_MOVIES.Models
{
	public class Actor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Firstname { get; set; }
		public string Path_Image { get; set; }

		public Actor() { }
		public Actor(int id, string firstname, string name, string path_rate)
		{
			Id = id;
			Name = name;
			Firstname = firstname;
			Path_Image = path_rate;
		}

	}
}