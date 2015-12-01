using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TODOs
{
	public partial class TodosPage : ContentView
	{
		private int projectId;
		private ContentPage rootPage;
		public TodosPage (ContentPage page)
		{
			InitializeComponent ();
			rootPage = page;
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
			projectMenuDialog.AddTodoButtonClicked += (sender1, args) => {
				var todoDetails = new TodoDetailsPage(rootPage, projectId);
				todoDetails.BackButtonClicked += (s, arg) => {
					contentPageArea.Children.Remove(todoDetails);
				};
				todoDetails.SaveButtonClicked += (s, arg) => {
					var eventSaveArgs = arg as TODOs.TodoDetailsPage.EventSaveArgs;
					if(eventSaveArgs != null) {
						App.DataBase.AddOrUpdateTodo(eventSaveArgs.Todo);
					}
					todosList.ItemsSource = App.DataBase.GetTodosByProjectId(projectId);
					contentPageArea.Children.Remove(todoDetails);
				};
				contentPageArea.Children.Remove(projectMenuDialog);
				contentPageArea.Children.Add (todoDetails, new Rectangle (0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
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

