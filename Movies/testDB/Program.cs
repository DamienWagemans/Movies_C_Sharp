using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace testDB
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var manager = new DALManager())
			{
				var movies = new Movies(1, "starwars","12/12/12" , 4,120,"google.be");

				manager.addMovie(movies);

			}
			Console.WriteLine("Demo completed.");

		}
	}
}
