using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_NET_MOVIES.Models
{
	public class Comment
	{
		public string Content { get; set; }
		public string Rate { get; set; }
		public string Avatar { get; set; }
		public string Date { get; set; }

		public Comment() { }
		public Comment(string content, string avatar, DateTime? date, string rate)
		{
			Content = content;
			Avatar = avatar;
			Date = String.Format("{0:dd/MM/yyyy}", date); ;
			Rate = rate;
		}
	}
}