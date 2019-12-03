using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DALManager : IDisposable
	{
		private readonly Movies_Context _movies_context;

		public DALManager ()
		{
			_movies_context = new Movies_Context();
		}
		public void Dispose()
		{
			_movies_context?.Dispose();
		}


		#region ADD to DB

		public void addMovie (Movie m)
		{
			_movies_context.TabMovies.Add(m);
			_movies_context.SaveChanges();
		}

		public void addActor(Actor a)
		{
			_movies_context.TabActor.Add(a);
			_movies_context.SaveChanges();
		}

		public void addCharacter(Character c)
		{
			_movies_context.TabCharacters.Add(c);
			_movies_context.SaveChanges();
		}

		public void addCharacterActor(CharacterActor ca)
		{
			_movies_context.TabCharacterActors.Add(ca);
			_movies_context.SaveChanges();
		}

		public void addComment(Comment c)
		{
			_movies_context.TabComments.Add(c);
			_movies_context.SaveChanges();
		}
		#endregion

		#region Film

		//Recherche un film par rapport à son Id.
		public Movie GetMovieById(int id)
		{
			return _movies_context.TabMovies.Find(id);
		}

		public ICollection<Movie> GetListFilmsByIdActor(int idActor)
		{
			var a = GetActorById(idActor);
			if (a == null)
				return null;
			return a.Movies;
		}

		public ICollection<Movie> FindXFilmByPartialActorName(string name, int nbElm)
		{
			var listFilm = new List<Movie>();

			var actor = _movies_context.TabActor.FirstOrDefault(x => x.Name.Contains(name));

			if (actor == null)
				return null;
			int i = 0;
			foreach (Movie m in actor.Movies)
			{
				if (i == nbElm)
					break;
				i++;
				listFilm.Add(m);
			}
			return listFilm;
		}

		public ICollection<Movie> Get10FavoriteFilms()
		{
			return _movies_context.TabMovies
						.OrderByDescending(f => f.Voteaverage)
					   .Take<Movie>(10).ToList();
		}


		public ICollection<Movie> GetXFilms(int nbr)
		{
			return _movies_context.TabMovies.Take<Movie>(nbr).ToList();
		}

		public ICollection<Movie> GetXFilmsFromY(int X, int Y)
		{
			return _movies_context.TabMovies.Skip<Movie>(Y).Take<Movie>(X).ToList();
		}
		#endregion

		#region Actor

		//Recherche un actor par rapport à son Id.
		public Actor GetActorById(int id)
		{
			return _movies_context.TabActor.Find(id);
		}

		#endregion

		#region Character

		//Recherche d'un character par son nom.
		public Character GetCharacter_by_name(string name)
		{
			var character = _movies_context.TabCharacters.SingleOrDefault(x => x.Charactername == name);
			return character;
		}

		public Character GetCharacterById(int id)
		{
			return _movies_context.TabCharacters.Find(id);
		}

		public ICollection<Character> GetCharacterByIdActorAndIdFilm(int actorId, int filmId)
		{
			var listCharacter = new List<Character>();

			IQueryable<Character> productCharacter = from ca in _movies_context.TabCharacterActors
													 where ca.ActorID == actorId &&
														   ca.MovieID == filmId
													 select ca.Character;

			//verif si y qql chose dans la list

			foreach (Character c in productCharacter)
				listCharacter.Add(c);


			return listCharacter;
		}

		#endregion

		#region Comment

		public Boolean InsertCommentOnActorId(int actorId, Comment comment)
		{
			var actor = _movies_context.TabActor.Find(actorId);

			if (actor == null)
				return false;

			comment.Actor = actor;
			_movies_context.TabComments.Add(comment);
			_movies_context.SaveChanges();

			return true;
		}

		#endregion



	}
}
