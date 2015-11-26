using System;
using TODOs;
using Xamarin.Forms.Platform.iOS;
using TODOs.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace TODOs.iOS
{
	public class MainPageRenderer : TabbedRenderer
	{
		public MainPageRenderer ()
		{
			TabBar.TintColor = Color.FromHex("#007caa").ToUIColor();
			TabBar.BarTintColor = Color.FromHex("#007caa").ToUIColor();
			TabBar.BackgroundColor = Color.White.ToUIColor();
		}
		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);
		}
	}
}

