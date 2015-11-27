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
			/*var list = new List<TodoModel> () {
				new TodoModel ()
				{
					Description = "Todo 1"
				},
				new TodoModel ()
				{
					Description = "Todo 2 l,elr,elv,pr,evr"
				},
				new TodoModel ()
				{
					Description = "Todo 3"
				},
				new TodoModel ()
				{
					Description = "Todo 4"
				}
			};*/
			InitializeComponent ();
			//todosList.ItemsSource = list;
		}
		public int ProjectId
		{
			get {
				return projectId;
			}
			set {
				projectId = value;
				// TODO select items from database
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
			if (contentPageArea != null) {
				contentPageArea.Children.Add (projectMenuDialog, new Rectangle(0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
			}
			if (MenuButtonClicked != null) {
				MenuButtonClicked (this, new EventArgs ());
			}
		}
	}
}

