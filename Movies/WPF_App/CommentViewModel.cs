using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace WPF_App
{
	class CommentViewModel
	{

		private CommentDTO Comment { get; set; }

		public CommentViewModel()
		{
			Comment = new CommentDTO();
		}

		public CommentViewModel(CommentDTO c)
		{
			this.Comment = c;
		}

		public string Date
		{
			get { return String.Format("{0:dd/MM/yyyy}", Comment.Date); }
		}
		public string Content
		{
			get { return Comment.Content; }
			set { Comment.Content = value; }
		}
		public int Rate
		{
			get { return Comment.Rate; }
			set { Comment.Rate = value; }
		}
		public string Avatar
		{
			get { return Comment.Avatar; }
			set { Comment.Avatar = value; }
		}




	}
}
