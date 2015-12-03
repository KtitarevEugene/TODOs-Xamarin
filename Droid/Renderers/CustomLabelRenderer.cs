using System;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using Xamarin.Forms;
using TODOs;
using TODOs.Droid;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace TODOs.Droid
{
	public class CustomLabelRenderer : LabelRenderer
	{
		public CustomLabelRenderer () : base ()
		{}
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				var view = Element as CustomLabel;
				if (view != null) {
					if(view.IsUnderlined) {
						Control.PaintFlags |= PaintFlags.UnderlineText;
					}
				}
			}
		}
		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var view = Element as CustomLabel;
			if (e.PropertyName == CustomLabel.IsUnderlinedProperty.PropertyName) {
				Control.PaintFlags = view.IsUnderlined ? Control.PaintFlags | PaintFlags.UnderlineText : Control.PaintFlags & ~PaintFlags.UnderlineText;
			}
		}
	}
}

