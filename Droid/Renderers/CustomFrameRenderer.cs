using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TODOs;
using TODOs.Droid;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace TODOs.Droid
{
	public class CustomFrameRenderer : FrameRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged (e);
			Background = Resources.GetDrawable (Resource.Drawable.roundedBorder);
		}
	}
}

