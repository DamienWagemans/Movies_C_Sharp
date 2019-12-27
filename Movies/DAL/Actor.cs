using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Actor: IComparable<Actor>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ActorID { get; set; }
		public string Firstname { get; set; }
		public string Name { get; set; }
		public virtual ICollection<CharacterActor> CharacterActors { get; set; }
		public virtual ICollection<Movie> Movies { get; set; }

		public Actor(string text) // Constructeur d’objet Actor
		{
			
			string [] actor_details = text.Split(' ');
			Firstname = actor_details[0];
			Name = actor_details[1];
			CharacterActors = new List<CharacterActor>();
			Movies = new List<Movie>();
		
		}


		public Actor()
		{
			Name = "temp";
			Firstname = "temp";
			CharacterActors = new List<CharacterActor>();
			Movies = new List<Movie>();
		}

		public void add_name_firstname(string text)
		{
			string[] actor_details = text.Split(' ');
			this.Firstname
				= actor_details[0];
			if(actor_details.Length > 1)
			{
				this.Name = actor_details[1];
			}
			else
			{
				this.Firstname = "Neant";
			}
		}



		public int CompareTo(Actor other)
		{
			if (this.ActorID == other.ActorID)
			{
				if (this.Name == other.Name)
				{
					if (this.Firstname == other.Firstname)
					{
						return 1;
					}
				}
			}
			return 0;

		}

		public override string ToString()
		{
			
			return ("Prénom : " + Firstname + "  Nom : " + Name + "\n");
		}
	}
}
