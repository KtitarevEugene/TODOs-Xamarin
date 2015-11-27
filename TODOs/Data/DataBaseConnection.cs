using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xamarin.Forms;


namespace TODOs
{
	public class DataBaseConnection
	{
		private static object syncObject = new object ();
		private static string DataBaseName = "TODOsSQLite.db3";

		SQLiteConnection database;

		public DataBaseConnection ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection (DataBaseName);
			database.CreateTable<ProjectModel> ();
		}
		public void AddOrUpdateProject (ProjectModel item)
		{
			lock (syncObject) {
				if (item.Id != 0) {
					database.Update (item);
				} else {
					database.Insert (item);
				}
			}
		}
		public IEnumerable<ProjectModel> GetAllProjects()
		{
			IEnumerable<ProjectModel> resultSet = null;
			lock (syncObject) {
				resultSet = (from current in database.Table<ProjectModel> ().OrderBy(x => x.ProjectName) select current).ToList ();
			}
			return resultSet;
		}
		public ProjectModel GetProjectById (int id)
		{
			ProjectModel result = null;
			lock (syncObject) {
				database.Table<ProjectModel> ().FirstOrDefault (x => x.Id == id);
			}
			return result;
		}
		public void RemoveProject(int id)
		{
			lock (syncObject) {
				database.Delete<ProjectModel> (id);
			}
		}
	}
}

