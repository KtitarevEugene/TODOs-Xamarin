using System;
using Xamarin.Forms;
using TODOs.iOS;
using System.IO;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace TODOs.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS () {}
		public SQLite.SQLiteConnection GetConnection (string databaseName)
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, databaseName);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}

