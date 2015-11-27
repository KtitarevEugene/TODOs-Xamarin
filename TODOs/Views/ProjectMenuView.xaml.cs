using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TODOs
{
	public partial class ProjectMenuView : ContentView
	{
		public ProjectMenuView ()
		{
			InitializeComponent ();
		}
		public event EventHandler CancelButtonClicked;
		public event EventHandler RemoveProjectButtonClicked;
		public event EventHandler AddTodoButtonClicked;

		public void OnCancelButtonClicked (object sender, EventArgs e)
		{
			if (CancelButtonClicked != null) {
				CancelButtonClicked (this, new EventArgs ());
			}
		}
		public void OnRemoveProjectButtonClicked (object sender, EventArgs e)
		{
			if (RemoveProjectButtonClicked != null) {
				RemoveProjectButtonClicked (this, new EventArgs ());
			}
		}
		public void OnAddTodoButtonClicked(object sender, EventArgs e)
		{
			if (AddTodoButtonClicked != null) {
				AddTodoButtonClicked (this, new EventArgs ());
			}
		}
	}
}

