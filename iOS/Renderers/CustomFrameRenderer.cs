using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TODOs;
using TODOs.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace TODOs.iOS
{
	public class CustomFrameRenderer : FrameRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged (e);
			Layer.CornerRadius = (nfloat)10.0;
		}
	}
}

