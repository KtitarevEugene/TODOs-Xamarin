using System;
using TODOs;
using TODOs.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer (typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace TODOs.iOS
{
	public class CustomEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				Control.Layer.CornerRadius = (nfloat)10.0;
			}
		}
	}
}

