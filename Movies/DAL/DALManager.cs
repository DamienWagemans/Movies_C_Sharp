using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class DALManager : IDisposable
	{
		private readonly Movies_Context _movies_context;

		public DALManager ()
		{
			_movies_context = new Movies_Context();
		}

		public void addMovie (Movies m)
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

		public void Dispose()
		{
			_movies_context?.Dispose();
		}
	}
}
