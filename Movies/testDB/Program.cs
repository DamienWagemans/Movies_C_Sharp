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
				FilmParser.Load_X_film(manager, "C:/Users/damien/Desktop/movies_v2.txt",10);
				Console.ReadLine();
			}
			Console.WriteLine("FIN");

		}
	}
}
