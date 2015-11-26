using System;
using Xamarin.Forms.Platform.Android;
using TODOs;
using TODOs.Droid;
using Xamarin.Forms;

[assembly:ExportRenderer (typeof(AboutPage), typeof(AboutPageRenderer))]
namespace TODOs.Droid
{
	public class AboutPageRenderer : PageRenderer
	{
		protected override void OnAttachedToWindow ()
		{
			base.OnAttachedToWindow ();
			SetBackgroundResource (Resource.Drawable.gradient);
		}
	}
}

