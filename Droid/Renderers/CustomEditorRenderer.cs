using System;
using Xamarin.Forms.Platform.Android;
using TODOs;
using TODOs.Droid;
using Xamarin.Forms;
using Android.Text;

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
				Control.SetHint (Resource.String.description);
				InputFilterLengthFilter filter = new InputFilterLengthFilter (255);
				Control.SetFilters (new IInputFilter[]{filter});
			}
		}
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
		}
	}
}
