using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class CharacterActor
	{
		[Key, Column(Order = 0)]
		public int ID_ACTOR { set; get; }
		
		[Key, Column(Order = 1)]
		public int ID_CHARACTER { set; get; }

		public CharacterActor(int idActor, int idCharacter)
		{
			ID_ACTOR = idActor;
			ID_ACTOR = idCharacter;
		}


		public virtual Actor Actor { get; set; }
		public virtual Character Character { get; set; }
	}
}
