using System;
using Xamarin.Forms.Platform.Android;
using TODOs;
using TODOs.Droid;
using Xamarin.Forms;

[assembly:ExportRenderer (typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace TODOs.Droid
{
	public class CustomEditorRenderer : EditorRenderer
	{
		protected override void OnAttachedToWindow ()
		{
			base.OnAttachedToWindow ();
			if (Control != null) {
				Control.Background = Resources.GetDrawable(Resource.Drawable.roundedBorder);
			}
		}
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
		}
	}
}
