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
		public int ActorID { set; get; }
		
		[Key, Column(Order = 1)]
		public int CharacterID { set; get; }

		[Key, Column(Order = 2)]
		public int MovieID { set; get; }

		public virtual Actor Actor { set; get; }
		public virtual Character Character { set; get; }
		
		public virtual Movie Movie { set; get; }

		public CharacterActor(int idActor, int idCharacter, int idFilm)
		{
			ActorID = idActor;
			CharacterID = idCharacter;
			MovieID = idFilm;
		}

		public CharacterActor(Movie m, Character c, Actor a)
		{
			Actor = a;
			Character = c;
			Movie = m;
		}

		public CharacterActor()
		{
			ActorID = 0;
			CharacterID = 0;
			MovieID = 0;
		}
	}
}
