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
		public string Name { get; set; }
		public virtual ICollection<CharacterActor> CharacterActors { get; set; }
		public virtual ICollection<Movie> Movies { get; set; }

		public Actor(string text) // Constructeur d’objet Actor
		{
			Name = text;
			CharacterActors = new List<CharacterActor>();
			Movies = new List<Movie>();
		}


		public Actor()
		{
			Name = "temp";
			CharacterActors = new List<CharacterActor>();
			Movies = new List<Movie>();

		}



		public int CompareTo(Actor other)
		{
			if (this.ActorID == other.ActorID)
			{
				if (this.Name == other.Name)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}

		}
	}
}
