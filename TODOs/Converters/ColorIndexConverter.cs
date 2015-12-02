using System;
using Xamarin.Forms;
using System.Globalization;

namespace TODOs
{
	public class ColorIndexConverter : IValueConverter
	{
		public const string ColorRed 	= "#ffccb4";
		public const string ColorBlue 	= "#acdafb";
		public const string ColorYellow	= "#fff9c6";
		public const string ColorWhite 	= "#ffffff";
		public const string ColorGreen 	= "#99d064";
		public ColorIndexConverter ()
		{}
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var todoModel = value as TodoModel;
			if (todoModel != null) {
				switch (todoModel.Color) {
					case TodoModel.ColorWhite: {
						return Color.FromHex(ColorWhite);
					}
					case TodoModel.ColorYellow: {
						return Color.FromHex(ColorYellow);
					}
					case TodoModel.ColorRed: {
						return Color.FromHex(ColorRed);
					}
					case TodoModel.ColorBlue: {
						return Color.FromHex(ColorBlue);
					}
					case TodoModel.ColorGreen: {
						return Color.FromHex (ColorGreen);
					}
					default: {
						return Color.FromHex(ColorWhite);
					}
				}
			}
			return Color.FromHex(ColorWhite);
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

