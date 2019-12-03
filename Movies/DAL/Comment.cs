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
		public DateTime Date { get; set; }
		public virtual Actor actor { get; set; }

		public Comment()
		{
			actor = new Actor();
			CommentId = 0;
			Content = "null";
			Rate = 0;
			Avatar = "John";
			ActorId = 0;
			Date = new DateTime();
		}
		public Comment(string content, int rate, string avatar, DateTime d, Actor a)
		{
			Content = content;
			Rate = rate;
			Avatar = avatar;
			Date = d;
			actor = a;
		}
		public Comment(string content, int rate, DateTime d)
		{
			Content = content;
			Rate = rate;
			Date = d;
		}
		public Comment(string content, int rate, DateTime d, Actor a)
		{
			Content = content;
			Rate = rate;
			Date = d;
			actor = a;
		}
		public Comment(string content, int rate)
		{
			Content = content;
			Rate = rate;
		}
		public virtual Actor Actor { get; set; }

	}
}
