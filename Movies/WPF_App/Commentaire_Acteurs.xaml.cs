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
using System.Windows.Shapes;
using DTO;

namespace WPF_App
{
	/// <summary>
	/// Interaction logic for Commentaire_Acteurs.xaml
	/// </summary>
	public partial class Commentaire_Acteurs : Window
	{
		private int ActorId;
		private Comments_ListViewModel List_Comments_Model;
		private int page_en_cours;
		private int nombre_de_pages;
		private WCF_Movie_Services.Service1Client WCF;

		public Commentaire_Acteurs()
		{
			InitializeComponent();

		}

		public Commentaire_Acteurs(int actorId)
		{
			InitializeComponent();
			WCF = new WCF_Movie_Services.Service1Client();

			page_en_cours = 1;
			Console.WriteLine("nombre_de_pages de comment : " + WCF.CountCommentsByActor(actorId));
			nombre_de_pages = WCF.CountCommentsByActor(actorId) / 5;
			nombre_de_pages++;

			ActorId = actorId;

			List_Comments_Model = new Comments_ListViewModel(actorId);
			
			List_Comments_Model.refresh_comments(5,0);
			pagination.Content = (page_en_cours + "/" + nombre_de_pages);

			label_actro_name.Content = List_Comments_Model.get_Name_Moyenne();
			CommentsDataGrid.DataContext = List_Comments_Model.Comments;
			
		}

		private void voir_commentaire_Click(object sender, RoutedEventArgs e)
		{
			if(textbox_note.Text != null && textbox_contenu != null && textbox_avatar != null)
			{
				Console.WriteLine("dans ajout!!!");
				int i;
				int.TryParse(textbox_note.Text, out i);
				CommentDTO comm = new CommentDTO(textbox_contenu.Text, i,textbox_avatar.Text, DateTime.Now);
				List_Comments_Model.insert_comment(comm, ActorId);

				nombre_de_pages = WCF.CountCommentsByActor(ActorId) / 5;
				nombre_de_pages++;
				pagination.Content = (page_en_cours + "/" + nombre_de_pages);

				List_Comments_Model.refresh_comments(5, (page_en_cours - 1) * 5);
				label_actro_name.Content = List_Comments_Model.get_Name_Moyenne();
			}
			
		}

		private void suivantclick(object sender, RoutedEventArgs e)
		{
			if (page_en_cours < nombre_de_pages)
			{
				page_en_cours++;
				List_Comments_Model.refresh_comments(5, (page_en_cours - 1) * 5);
				pagination.Content = (page_en_cours + "/" + nombre_de_pages);
			}
		}

		private void bouton_precedent_DragEnter(object sender, DragEventArgs e)
		{

		}

		private void precedentclick(object sender, RoutedEventArgs e)
		{
			if (page_en_cours > 1)
			{
				page_en_cours--;
				List_Comments_Model.refresh_comments(5, (page_en_cours - 1) * 5);
				pagination.Content = (page_en_cours + "/" + nombre_de_pages);
			}
		}
	}
}
