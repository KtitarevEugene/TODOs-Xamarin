using System;
using Xamarin.Forms;
using System.Globalization;

namespace TODOs
{
	public class TodoTypeConverter : IValueConverter
	{
		public const string IconFeature = "feature.png";
		public const string IconBug 	= "bug.png";
		public const string IconDefault = "bug.png";
		public TodoTypeConverter()
		{}
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var todoModel = value as TodoModel;
			if (value != null) {
				switch (todoModel.Type) {
					case TodoModel.TypeBug: {
						return IconBug;
					}
					case TodoModel.TypeFeature: {
						return IconFeature;
					}
					default: {
						return IconDefault;
					}
				}
			}
			return value;
		}
		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

