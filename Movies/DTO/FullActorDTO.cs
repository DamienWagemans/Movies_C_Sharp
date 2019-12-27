using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class FullActorDTO : ActorDTO
	{
		public virtual ICollection<LightMovieDTO> Movies { get; set; }
		public virtual ICollection<CommentDTO> comment { get; set;}

		public FullActorDTO() : base()
		{
			Movies = new List<LightMovieDTO>();
			comment = new List<CommentDTO>();
		}
	}
}
