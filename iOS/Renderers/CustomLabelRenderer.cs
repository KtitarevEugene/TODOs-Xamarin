using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using TODOs;
using TODOs.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace TODOs.iOS
{
	public class CustomLabelRenderer : LabelRenderer
	{
		public CustomLabelRenderer () : base()
		{}
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Label> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				SetAttributedString ();
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == CustomLabel.IsUnderlinedProperty.PropertyName) {
				SetAttributedString ();
			}
		}
		private void SetAttributedString()
		{
			var view = Element as CustomLabel;
			UIStringAttributes attr = new UIStringAttributes () {
				Font = Control.Font,
				ForegroundColor = Control.TextColor,
				BackgroundColor = Control.BackgroundColor,
				UnderlineStyle = view != null && view.IsUnderlined ? Foundation.NSUnderlineStyle.Single : Foundation.NSUnderlineStyle.None
			};
			Control.AttributedText = new Foundation.NSAttributedString(Control.Text, attr);
		}
	}
}

