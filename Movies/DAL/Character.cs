using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Character
	{
		public int ID { get; set; }
		public string Charactername { set; get; }

		public Character(int id, string charactername)
		{
			ID = id;
			Charactername = charactername;
		}

		public virtual ICollection<CharacterActor> CharactersActors { get; set; }

	}
}
