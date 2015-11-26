using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TODOs
{
	public class ActionSheetEventArgs : EventArgs
	{
		public String ProjectName { get; private set; }
		public ActionSheetEventArgs(String projectName) :base()
		{
			ProjectName = projectName;
		}
	}
	public partial class CreateProjectView : ContentView
	{
		public CreateProjectView ()
		{
			InitializeComponent ();
		}
		public void OnCancelButtonClicked (object sender, EventArgs e)
		{
			if (CancelClicked != null) {
				CancelClicked (this, new ActionSheetEventArgs(projectNameFiled.Text));
			}
		}
		public void OnCreateButtonClicked (object sender, EventArgs e)
		{
			if (CreateClicked != null) {
				CreateClicked (this, new ActionSheetEventArgs(projectNameFiled.Text));
			}
		}
		public delegate void ActionSheetEventHandler (object sender, EventArgs e);

		public event ActionSheetEventHandler CreateClicked;

		public event ActionSheetEventHandler CancelClicked;
	}
}

