using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class CharacterDTO
	{
		public int CharacterDTOId { get; set; }
		public string Name { get; set; }


		public CharacterDTO()
		{
			CharacterDTOId = 0;
			Name = "Bidon";
		}

		public CharacterDTO(int id, string name)
		{
			CharacterDTOId = id;
			Name = name;
		}

		public override string ToString()
		{
			return "CharacterDTO id:" + CharacterDTOId + "  " + Name;
		}
	}
}
