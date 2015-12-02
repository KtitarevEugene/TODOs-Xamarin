﻿using System;
using TODOs;
using TODOs.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

[assembly:ExportRenderer (typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace TODOs.iOS
{
	public class CustomEditorRenderer : EditorRenderer
	{
		private UIColor textColor;
		public CustomEditorRenderer() : base()
		{
		}
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
			if (Control != null) {
				Control.Layer.CornerRadius = (nfloat)10.0;
				if (textColor == null) {
					textColor = Control.TextColor;
				}
				if (String.IsNullOrEmpty (Control.Text)) {
					Control.AttributedText = new NSAttributedString ("Description", Control.Font, UIColor.Gray);
				}
				Control.ShouldBeginEditing = ((textView) => {
					if (textView.Text.CompareTo("Description") == 0) {
						textView.Text = String.Empty;
						textView.TextColor = textColor;
					}
					return true;
				});
				Control.ShouldChangeText = ((view, range, text) => {
					int textLimit = 255;
					if ((view.Text.Length - range.Length) + text.Length <= textLimit) {
						return true;
					}
					var emptySpace = Math.Max (0, textLimit - (view.Text.Length - range.Length));
					var beforeCaret = view.Text.Substring (0, (int)range.Location) + text.Substring (0, (int)emptySpace);
					var afterCaret = view.Text.Substring ((int)(range.Location + range.Length));

					view.Text = beforeCaret + afterCaret;
					view.SelectedRange = new NSRange (beforeCaret.Length, 0);

					return false;
				});
				Control.ShouldEndEditing = ((textView) => {
					if (String.IsNullOrEmpty(textView.Text)) {
						textView.AttributedText = new NSAttributedString ("Description", Control.Font, UIColor.Gray);
					}
					return true;
				});

			}
		}
	}
}

