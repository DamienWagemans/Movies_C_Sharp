using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class Film
	{

		public int ID { get; set; }
		public string Title { get; set; }

		public DateTime Realeasedate { get; set; }
		public int Voteaverage { get; set; }

		public int Runtime { get; set; }

		public string Posterpath { get; set; }

		public virtual ICollection<Character> Characters { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }

		public Film(int id, string title, DateTime realeasedate, int voteaverage, int runtime, string posterpath)
		{
			ID = id;
			Title = title;
			Realeasedate = realeasedate;
			Voteaverage = voteaverage;
			Runtime = runtime;
			Posterpath = posterpath;
		}

	}

	
}
