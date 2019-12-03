using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class ActorDTO
	{
		public int ActorId { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }

		public ActorDTO()
		{
			ActorId = 0;
			Surname = "Bidon";
			Name = "Bidon";
		}

		public ActorDTO(int id, string name,string surname)
		{
			ActorId = id;
			Surname = surname;
			Name = name;
		}
		public override string ToString()
		{
			return "ActorDTP id:" + ActorId + "  " + Name + "  " + Surname;
		}
	}
}
