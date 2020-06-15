using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
	public class Singleton
	{
		private static Singleton theInstance = null;

		private Singleton()
		{ }

		public static Singleton GetInstance()
		{
			if (theInstance == null)
			{
				Console.WriteLine("L'istanza non esiste, la creo");
				theInstance = new Singleton();
			}
			Console.WriteLine("ecco l'istanza "+theInstance.GetHashCode());
			return theInstance;
		}
	}

}
