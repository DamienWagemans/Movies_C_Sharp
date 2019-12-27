using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Actors_ListViewModel List_Actors_Model;
		private Movies_ListViewModel List_Movies_Model;
		private WCF_Movie_Services.Service1Client WCF;

		int page_en_cours;
		int nombre_de_pages;
		

		public MainWindow()
		{
			InitializeComponent();
			List_Actors_Model = new Actors_ListViewModel();
			List_Movies_Model = new Movies_ListViewModel();
			
			WCF = new WCF_Movie_Services.Service1Client();
			
			page_en_cours = 1;
			nombre_de_pages = WCF.GetCountActors() / 10;

			List_Actors_Model.refresh_list(10, 1);
			pagination.Content = (page_en_cours + "/" + nombre_de_pages);

			ActorDataGrid.DataContext = List_Actors_Model.Actors;
			MoviesDataGrid.DataContext = List_Movies_Model.Movies;
		}


		private void click_suivant(object sender, RoutedEventArgs e)
		{
			if(page_en_cours<nombre_de_pages)
			{
				page_en_cours++;
				List_Actors_Model.refresh_list(10, (page_en_cours-1) * 10);
				pagination.Content = (page_en_cours + "/" + nombre_de_pages);
			}

		}

		private void click_precedent(object sender, RoutedEventArgs e)
		{
			if(page_en_cours>1)
			{
				page_en_cours--;
				List_Actors_Model.refresh_list(10, (page_en_cours-1) * 10);
				pagination.Content = (page_en_cours + "/" + nombre_de_pages);
			}
		}

		private void changement_texte(object sender, TextChangedEventArgs e)
		{
			List_Actors_Model.refresh_list_by_nom(recherche_par_nom.Text);
		}

		private void MoviesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
		}

		private void ActorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void MoviesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ActorDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ActorViewModel a = (ActorViewModel)ActorDataGrid.SelectedValue;
			List_Movies_Model.Details_Actor_Movies(a);
			Nom_label.Content = a.Name;
			prenom_label.Content = a.Firstname;
		}

		private void voir_commentaire_Click(object sender, RoutedEventArgs e)
		{
			if(ActorDataGrid.SelectedValue != null)
			{
				ActorViewModel actor = new ActorViewModel();
				actor = (ActorViewModel)ActorDataGrid.SelectedValue;
				Commentaire_Acteurs CA = new Commentaire_Acteurs(actor.ActorId);
				CA.ShowDialog();
			}
		}
	}
}
