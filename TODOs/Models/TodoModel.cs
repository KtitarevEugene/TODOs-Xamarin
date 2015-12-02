using System;
using SQLite;

namespace TODOs
{
	public class TodoModel
	{
		public const ushort TypeFeature			      = 1;
		public const ushort TypeBug 				  = 0;
		public const ushort StatusNew   			  = 1;
		public const ushort StatusFixedOrImplemented  = 0;

		public const ushort ColorWhite 	= 0;
		public const ushort ColorYellow = 1;
		public const ushort ColorRed 	= 2;
		public const ushort ColorBlue 	= 3;
		public const ushort ColorGreen 	= 4;


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
		public ushort Color { get; set; }
		public int ProjectId { get; set; }
	}
}

