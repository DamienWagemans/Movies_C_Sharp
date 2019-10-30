using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Comment
	{
		public int ID { set; get; }
		public string Content { get; set; }
		public int Rate { get; set;}

		public Comment(int id, string content, int rate)
		{
			ID = id;
			Content = content;
			Rate = rate;
		}

		public virtual Movies Film { get; set; }

	}
}
