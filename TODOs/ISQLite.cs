using System;
using SQLite;

namespace TODOs
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection(string databaseName);
	}
}

