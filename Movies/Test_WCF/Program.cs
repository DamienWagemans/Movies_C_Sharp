using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Test_WCF
{
	class Program
	{
		static void Main(string[] args)
		{
			var WCF = new ServiceReferenceFilm.Service1Client();
			var list = WCF.GetMovieByIdActor(4826);
			foreach(MovieDTO m in list)
			{
				Console.WriteLine(m);
			}
		}
	}
}
