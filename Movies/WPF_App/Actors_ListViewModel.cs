using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace WPF_App
{
	class Actors_ListViewModel
	{ 

		public ObservableCollection<ActorViewModel> Actors;
		private WCF_Movie_Services.Service1Client WCF;

		public Actors_ListViewModel()
		{
			WCF = new WCF_Movie_Services.Service1Client();
			Actors = new ObservableCollection<ActorViewModel>();
		}


		public void refresh_list(int X, int Y)
		{
			Actors.Clear();
			ICollection<ActorDTO> ActorsDTO = new List<ActorDTO>();
			ActorsDTO = WCF.GetXActorsFromY(X, Y);
			foreach (ActorDTO a in ActorsDTO)
				Actors.Add(new ActorViewModel(a));
		}

		public void refresh_list_by_nom(String nom)
		{
			Actors.Clear();
			var list = WCF.GetXActorsByName(nom, 10);
			foreach (ActorDTO a in list)
				Actors.Add(new ActorViewModel(a));
		}

		public void Add(ActorViewModel act)
		{
			Actors.Add(act);
		}
	}
}
