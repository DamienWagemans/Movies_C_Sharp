using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace WPF_App
{
	public class ActorViewModel
	{
		private ActorDTO Actor { get; set; }

		public ActorViewModel()
		{
			Actor = new ActorDTO();
		}

		public ActorViewModel(ActorDTO a)
		{
			Actor = a;
		}

		public int ActorId
		{
			get { return Actor.ActorId; }
			set { Actor.ActorId = value; }
		}
		public string Name
		{
			get { return Actor.Name; }
			set { Actor.Name = value; }
		}

		public string Firstname
		{
			get { return Actor.Firstname; }
			set { Actor.Firstname = value; }
		}

	}
}
