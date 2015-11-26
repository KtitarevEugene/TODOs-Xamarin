using System;
using Xamarin.Forms.Platform.iOS;
using TODOs;
using Xamarin.Forms;
using TODOs.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace TODOs.iOS
{
	public class CustomListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				Control.SeparatorColor = Color.Transparent.ToUIColor ();
			}
		}
	}
}

