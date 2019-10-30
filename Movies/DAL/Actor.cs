using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Actor
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public Actor(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public Actor()
		{
			ID = 0;
			Name = "temp";
		}

		public virtual ICollection<CharacterActor> CharacterActor { get; set; }
		public virtual ICollection<Movies>Movies { get; set; }

	}
}
