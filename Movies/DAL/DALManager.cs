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

		public Actor getActor_by_ID(int id)
		{
			Actor a;
			a = _movies_context.TabActor.Find(id);
			return a;
		}

		public Movie getMovie_by_ID(int id)
		{
			Movie m;
			m = _movies_context.TabMovies.Find(id);
			return m;
		}

		//public Character GetCharacter_by_name(string name)
		//{
		//	using (var context = new Movies_Context())
		//	{
		//		var query = from c in context.TabCharacters
		//			where c.Charactername == name
		//			select c;

		//		var Character = query.FirstOrDefault<Character>();
		//		return Character;
		//	}
		//}

		public Character GetCharacter_by_name(string name)
		{
			var character = _movies_context.TabCharacters.SingleOrDefault(x => x.Charactername == name);
			return character;
		}


		//public Movie getXMovies(int x)
		//{
		//	using (var context = new Movies_Context())
		//	{
		//		var query = from st in context.TabMovies
		//					select st;

		//		var Movies = query.First<Movie>(5);
		//		return Movies;
		//	}

		//}



		// get5movies
		//get actor by id
		//utiliser linq  (query implement IQueryable -> .first / .skip(x) ./take(x) .tolist()
		//faire une fonction qui renvoit n film a aprtir du Nieme

		public void Dispose()
		{
			_movies_context?.Dispose();
		}
	}
}
