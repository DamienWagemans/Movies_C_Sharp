using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class ActorDTO
	{
		public int ActorId { get; set; }
		public string Firstname { get; set; }
		public string Name { get; set; }

		public ActorDTO()
		{
			ActorId = 0;
			Firstname = "Bidon";
			Name = "Bidon";
		}

		public ActorDTO(int id, string name,string firstname)
		{
			ActorId = id;
			Firstname = firstname;
			Name = name;
		}
		public override string ToString()
		{
			return "ActorDTP id:" + ActorId + " Name : " + Name + " FirstName : " + Firstname;
		}
	}
}
