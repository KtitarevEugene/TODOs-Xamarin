using System;
using SQLite;

namespace TODOs
{
	public class TodoModel
	{
		public static readonly ushort TypeFeature			 	= 1;
		public static readonly ushort TypeBug 				 	= 0;
		public static readonly ushort StatusNew   				= 1;
		public static readonly ushort StatusFixedOrImplemented  = 0;

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

