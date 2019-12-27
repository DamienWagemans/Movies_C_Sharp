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
		public int CommentId { get; set; }
		public string Content { get; set; }
		public int Rate { get; set; }
		public string Avatar { get; set; }
		public int ActorId { get; set; }
		public DateTime? Date { get; set; }
		public virtual Actor Actor { get; set; }

		public Comment()
		{
			Actor = new Actor();
			CommentId = 0;
			Content = "null";
			Rate = 0;
			Avatar = "John";
			ActorId = 0;
			Date = DateTime.Now;
		}
		public Comment(string content, int rate, string avatar, DateTime? d, Actor a)
		{
			Content = content;
			Rate = rate;
			Avatar = avatar;
			Date = d;
			Actor = a;
		}
		public Comment(string content, int rate, DateTime? d)
		{
			Content = content;
			Rate = rate;
			Date = d;
			Avatar = "null";
			Actor = new Actor();
		}

		public Comment(string content, int rate, string avatar, DateTime? date)
		{
			Content = content;
			Rate = rate;
			Avatar = avatar;
			Date = date;
			Actor = new Actor();
		}
		public Comment(string content, int rate, DateTime? d, Actor a)
		{
			Content = content;
			Rate = rate;
			Date = d;
			Actor = a;
			Avatar = "null";
		}
		public Comment(string content, int rate)
		{
			Content = content;
			Rate = rate;
			Date = DateTime.Now;
			Avatar = "null";
			Actor = new Actor();

		}

	}
}
