using System;
using SQLite;

namespace TODOs
{
	public class TodoModel
	{
		public readonly int TypeFeature				 = 1;
		public readonly int TypeBug 				 = 0;
		public readonly int StatusNew   			 = 1;
		public readonly int StatusFixedOrImplemented = 0;

		public TodoModel ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }

		// Feature - 0 Bug - 1;
		public ushort Type { get; set; }

		// New - 0 Fixed/Implemented - 1 (Fixed or Implemented depends upon type)
		public ushort Status { get; set; }
		public int ProjectId { get; set; }
	}
}

