using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Comment
	{
		[Key]
		public int Id { set; get; }
		public string Content { get; set; }
		public int Rate { get; set;}

		public Comment(int id, string content, int rate)
		{
			Id = id;
			Content = content;
			Rate = rate;
		}

		public Comment()
		{
			Id = 0;
			Content = "NUL!";
			Rate = 0;
		}

		public virtual Movie Film { get; set; }

	}
}
