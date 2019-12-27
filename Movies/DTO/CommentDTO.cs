using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
	public class CommentDTO
	{
		public string Content { get; set; }
		public DateTime? Date { get; set; }

		private int _rate;
		public int Rate //De 1 à 5
		{
			get { return _rate; }
			set
			{
				if (value > 5)
					_rate = 5;
				else if (value < 0)
					_rate = 0;
				else
					_rate = value;
			}
		}
		public string Avatar { get; set; }

		public CommentDTO()
		{
			Content = "bidon";
			Rate = 0;
			Avatar = "bidon";
			Date = DateTime.Now ;
		}

		public CommentDTO(string content, int rate, string avatar)
		{
			Content = content;
			Rate = rate;
			Avatar = avatar;
			Date = DateTime.Now;

		}

		public CommentDTO(string content, int rate, string avatar, DateTime? d)
		{
			Content = content;
			Rate = rate;
			Avatar = avatar;
			Date = d;
		}

		public override string ToString()
		{
			return "CommentDTO : " + Content + " Rate: " + Rate + " (" + Avatar + ")";
		}
	}
}
