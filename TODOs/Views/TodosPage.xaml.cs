using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TODOs
{
	public partial class TodosPage : ContentView
	{
		private int projectId;
		public TodosPage ()
		{
			InitializeComponent ();
		}
		public int ProjectId
		{
			get {
				return projectId;
			}
			set {
				projectId = value;
				todosList.ItemsSource = App.DataBase.GetTodosByProjectId(projectId);
			}
		}

		public event EventHandler BackButtonClicked;
		public event EventHandler MenuButtonClicked;
		public void OnBackButtonClicked (object sender, EventArgs e)
		{
			if (BackButtonClicked != null) {
				BackButtonClicked (this, new EventArgs());
			}
		}
		public void OnMenuButtonClicked (object sender, EventArgs e)
		{
			var contentPageArea = this.FindByName<AbsoluteLayout> ("contentPageArea");
			var projectMenuDialog = new ProjectMenuView ();
			projectMenuDialog.CancelButtonClicked += (sender1, args) => {
				contentPageArea.Children.Remove(projectMenuDialog);
			};
			projectMenuDialog.RemoveProjectButtonClicked += (sender1, args) => {
				App.DataBase.RemoveTodosByProjectId(projectId);
				App.DataBase.RemoveProject(projectId);
				contentPageArea.Children.Remove(projectMenuDialog);
				if (BackButtonClicked != null) {
					BackButtonClicked (this, new EventArgs());
				}
			};
			if (contentPageArea != null) {
				contentPageArea.Children.Add (projectMenuDialog, new Rectangle(0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
			}
			if (MenuButtonClicked != null) {
				MenuButtonClicked (this, new EventArgs ());
			}
		}
	}
}

