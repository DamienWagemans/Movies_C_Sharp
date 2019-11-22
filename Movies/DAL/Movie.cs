using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Movie
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int MovieID { get; set; }
		public string Title { get; set; }
		public DateTime? Releasedate { get; set; }
		public float Voteaverage { get; set; }
		public int Runtime { get; set; }
		public string Posterpath { get; set; }

		public virtual ICollection<Actor> Actors { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }

		public Movie(int id, string title, DateTime realeasedate, float voteaverage, int runtime, string posterpath)
		{
			MovieID = id;
			Title = title;
			Releasedate = realeasedate;
			Voteaverage = voteaverage;
			Runtime = runtime;
			Posterpath = posterpath;
			Comments = new List<Comment>();
			Actors = new List<Actor>();

		}

		public Movie()
		{
			MovieID = 0;
			Title = "NEANT";
			Releasedate = new DateTime();
			Voteaverage = 0;
			Runtime = 120;
			Posterpath = "WWW.GOOGLE.COM";
			Comments = new List<Comment>(); 
			Actors = new List<Actor>();
		}

		public override string ToString()
		{
			string film;
			film = "ID :" + MovieID + " / Titre : " + Title + " / Release Date : " + Releasedate;

			film += "/ Acteurs : ";
			foreach (Actor a in (Actors))
			{
				film += "//Nom : " + a.ToString();
			}
			return film;
		}
	}

	
}
