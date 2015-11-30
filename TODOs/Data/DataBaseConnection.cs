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
			database.CreateTable<TodoModel> ();
		}
		public void AddOrUpdateProject (ProjectModel item)
		{
			lock (syncObject) {
				if (item.Id == 0) {
					database.Insert (item);
				} else {
					database.Update (item);
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
		public void AddOrUpdateTodo(TodoModel item)
		{
			lock (syncObject) {
				if (item.Id == 0) {
					database.Insert (item);
				} else {
					database.Update (item);
				}
			}
		}
		public IEnumerable<TodoModel> GetTodosByProjectId (int projectId)
		{
			IEnumerable<TodoModel> resultSet = null;
			lock (syncObject) {
				resultSet = (from current in database.Table<TodoModel> ()
				             where current.ProjectId == projectId
							 select current).OrderBy (x => x.Status).OrderBy (x => x.Type);
			}
			return resultSet;
		}
		public TodoModel GetTodoById(int id)
		{
			TodoModel result = null;
			lock (syncObject) {
				result = database.Table<TodoModel> ().FirstOrDefault (x => x.Id == id);
			}
			return result;
		}
		public void RemoveTodo (int id)
		{
			lock (syncObject) {
				database.Delete<TodoModel>(id);
			}
		}
		public void RemoveTodosByProjectId(int projectId)
		{
			lock (syncObject) {
				database.Table<TodoModel> ().Delete (x => x.ProjectId == projectId);
			}
		}
	}
}

