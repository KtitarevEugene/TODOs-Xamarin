using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TODOs;
using TODOs.Droid;

[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(CustomStackLayoutRenderer))]
namespace TODOs.Droid
{
	public class CustomStackLayoutRenderer : ViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				Control.Background = Resources.GetDrawable (Resource.Drawable.roundedBorder);
			}
		}
	}
}

