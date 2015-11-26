using System;
using Xamarin.Forms;
using TODOs.Droid;
using System.IO;

[assembly: Dependency (typeof(SQLite_Android))]
namespace TODOs.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android () {}
		public SQLite.SQLiteConnection GetConnection (string databaseName)
		{
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, databaseName);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}

