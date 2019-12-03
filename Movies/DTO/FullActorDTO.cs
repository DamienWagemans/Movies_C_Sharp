using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	class FullActorDTO : ActorDTO
	{
		public virtual ICollection<MovieDTO> film { get; set; }
		public virtual ICollection<CommentDTO> comment { get; set;}

		public FullActorDTO() : base()
		{
			film = new HashSet<MovieDTO>();
			comment = new HashSet<CommentDTO>();
		}
	}
}
