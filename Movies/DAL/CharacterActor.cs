using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class CharacterActor
	{
		public int ID_actor { set; get; }
		public int ID_character { set; get; }

		public CharacterActor(int idActor, int idCharacter)
		{
			ID_actor = idActor;
			ID_character = idCharacter;
		}


		public virtual Actor Actor { get; set; }
		public virtual Character Character { get; set; }
	}
}
