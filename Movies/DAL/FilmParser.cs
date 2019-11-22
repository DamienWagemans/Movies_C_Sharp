using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class FilmParser
	{
		private static StreamReader f = null;
		private static string[] filmdetailwords;
		private static string[] acteurs;

		public FilmParser()
		{
		}

		public static void Load_X_film (DALManager dm, string filepath, int X)
		{
			f = new StreamReader(filepath);
			for (int i = 0; i < X; i++)
			{
				string line = f.ReadLine();
				Console.WriteLine("Ligne : " + i);
				DecodeFilmText(dm, line);
			}
		}

		private static void DecodeFilmText(DALManager dm, string filmtext)
		{

			//decomposition du film
			Char[] delimiterChars = {'\u2023'};
			filmdetailwords = filmtext.Split(delimiterChars);
			delimiterChars[0] = '\u2016';

			// Initialisation des champs de base du film
			Movie m = new Movie();
			m.MovieID = Int32.Parse(filmdetailwords[0]);
			m.Title = filmdetailwords[1];
			m.Releasedate = DateTime.ParseExact(filmdetailwords[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
			m.Voteaverage = float.Parse(filmdetailwords[5], CultureInfo.InvariantCulture.NumberFormat); ;
			m.Runtime = Int32.Parse(filmdetailwords[7]);
			m.Posterpath = filmdetailwords[9];

			//verifier si il existe déja dans la BD
			if(dm.getMovie_by_ID(m.MovieID)== null)
			{ 

				// Initialisation des champs détails du film
				if (filmdetailwords.Length == 15)
				{
					acteurs = filmdetailwords[14].Split(delimiterChars);
					foreach (string s in acteurs)
					{
						if (s.Length > 0)
						{
							string[] acteurs_details, characterdetail;
	
							Actor a = new Actor();

							//recuperation des details de l'acteur
							delimiterChars[0] = '\u2024';
							acteurs_details = s.Split(delimiterChars);


							//cretion de l'acteur et/ou verif si l'acteur existe deja
							a.ActorID = Int32.Parse(acteurs_details[0]);
							a.Name = acteurs_details[1];
							var tmpActor = dm.getActor_by_ID(a.ActorID);
							if (tmpActor != null)
							{
								a = tmpActor;
							}


							//liaison du film avec l'acteur et vice versa
							a.Movies.Add(m);
							m.Actors.Add(a);


							Character c = new Character (acteurs_details[2]);
							var tmpCharacter = dm.GetCharacter_by_name(c.Charactername);
							if (tmpCharacter != null)
							{ 
								c = tmpCharacter;
							}


							CharacterActor CA = new CharacterActor(m,c,a);
							
							dm.addCharacterActor(CA);

						}
					}
				}
			}
			else
			{
				Console.WriteLine("Film existe deja ");
			}
		}
	}
}

		

