using System;

using Xamarin.Forms;

namespace TODOs
{
	public class App : Application
	{
		private static DataBaseConnection db;
		public static DataBaseConnection DataBase { get {return db;} }
		public App ()
		{
			db = new DataBaseConnection ();
			MainPage = new MainPage ();
		}
	}
}

