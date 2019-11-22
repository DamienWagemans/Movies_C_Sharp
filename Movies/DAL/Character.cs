using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Character
	{
		public int CharacterID { get; set; }
		public string Charactername { set; get; }

		public virtual ICollection<CharacterActor> CharacterActors { get; set; }
		public Character(string charactername)
		{
			Charactername = charactername;
			CharacterActors = new List<CharacterActor>();
		}

		public Character()
		{ 
			Charactername = null;
			CharacterActors = new List<CharacterActor>();
		}

		public override string ToString()
		{
			string c;
			c = ("Character : " + this.CharacterID + " name : " + this.Charactername);
			return c;
		}
	}
}
