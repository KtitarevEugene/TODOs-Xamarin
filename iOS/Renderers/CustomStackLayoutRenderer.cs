using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TODOs;
using TODOs.iOS;

[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(CustomStackLayoutRenderer))]
namespace TODOs.iOS
{
	public class CustomStackLayoutRenderer : ViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				Control.Layer.CornerRadius = (nfloat)10.0;
			}
		}
	}
}

