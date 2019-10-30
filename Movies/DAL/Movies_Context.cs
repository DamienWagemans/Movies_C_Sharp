using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class Movies_Context : DbContext
	{
		public Movies_Context(): base(@"Server=localhost\SQLEXPRESS;Database=movies_C_SHARP;Trusted_Connection=True;") { }


		public DbSet<Movies> TabMovies { get; set; }
		public DbSet<Actor> TabActor { get; set; }
		public DbSet<Character> TabCharacters { get; set; }
		public DbSet<Comment> TabComments { get; set; }
		public DbSet<CharacterActor> TabCharacterActors { get; set; }



	}
}
