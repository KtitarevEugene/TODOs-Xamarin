using System;
using SQLite;

namespace TODOs
{
	public class ProjectModel
	{
		public ProjectModel()
		{
		}
		public ProjectModel(string projectName)
		{
			ProjectName = projectName;
		}
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string ProjectName { set; get; }
	}
}

