using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TODOs
{
	public partial class TodosPage : ContentView
	{
		private int projectId;
		private ObservableCollection<TodoModel> itemsList;
		private ContentPage rootPage;
		public TodosPage (ContentPage page)
		{
			InitializeComponent ();
			itemsList = new ObservableCollection<TodoModel> ();
			rootPage = page;
			todosList.ItemsSource = itemsList;
		}
		public int ProjectId
		{
			get {
				return projectId;
			}
			set {
				projectId = value;
				ResetListData ();
			}
		}

		public event EventHandler BackButtonClicked;
		public event EventHandler MenuButtonClicked;
		private void OnBackButtonClicked (object sender, EventArgs e)
		{
			if (BackButtonClicked != null) {
				BackButtonClicked (this, new EventArgs());
			}
		}
		private void OnMenuButtonClicked (object sender, EventArgs e)
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
					ResetListData();
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
		private void ResetListData ()
		{
			IEnumerable<TodoModel> list = App.DataBase.GetTodosByProjectId (projectId);
			itemsList.Clear ();
			foreach (TodoModel item in list) {
				itemsList.Add (item);
			}
		}
		private void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var listView = sender as CustomListView;
			if (listView != null) {
				listView.SelectedItem = null;
			}
			var todoModel = e.SelectedItem as TodoModel;
			if (todoModel != null) {
				var todoDetails = new TodoDetailsPage (rootPage, todoModel);
				todoDetails.BackButtonClicked += (s, arg) => {
					contentPageArea.Children.Remove (todoDetails);
				};
				todoDetails.RemoveButtonClicked += (sender1, args) => {
					App.DataBase.RemoveTodo (todoModel.Id);
					ResetListData ();
					contentPageArea.Children.Remove (todoDetails);
				};
				todoDetails.SaveButtonClicked += (sender1, args) => {
					var todo = args.Todo;
					App.DataBase.AddOrUpdateTodo (todo);
					ResetListData ();
					contentPageArea.Children.Remove (todoDetails);
				};
				contentPageArea.Children.Add (todoDetails, new Rectangle (0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
			}
		}
	}
}

