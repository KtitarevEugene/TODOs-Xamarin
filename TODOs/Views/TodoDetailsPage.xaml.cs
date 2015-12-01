using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Globalization;

namespace TODOs
{
	public partial class TodoDetailsPage : ContentView
	{
		private int id;
		private int projectId;
		private ContentPage rootPage;

		private readonly string TYPE_BUG = "Bug";
		private readonly string TYPE_FEATURE = "Feature";
		private readonly string STATUS_NEW = "New";
		private readonly string STATUS_FIXED = "Fixed";
		private readonly string STATUS_IMPLEMENTED = "Implemented";
		private readonly string OPTION_CANCEL = "Cancel";

		public class EventSaveArgs : EventArgs
		{
			public EventSaveArgs(TodoModel model) : base()
			{
				Todo = model;
			}
			public TodoModel Todo { get; private set; }
		}
		public delegate void EventSaveHandler (object sender, EventSaveArgs args);
		public event EventSaveHandler EventSaved;

		public TodoDetailsPage (ContentPage page, int projectId, int todoId = 0) : base()
		{
			InitializeComponent ();
			if (todoId == 0) {
				todosDate.Text = DateTime.Now.ToString ("ddd MMM dd yyyy HH:mm:ss");
			} else {
				// TODO Edit mode;
			}
			this.projectId = projectId;
			id = todoId;
			rootPage = page;
		}
		public void OnBackButtonClicked(object sender, EventArgs e)
		{
			// TODO back
		}
		public void OnRemoveButtonClicked(object sender, EventArgs e)
		{
			// TODO remove
		}
		public void OnSaveButtonClicked(object sender, EventArgs e)
		{
			TodoModel todo = new TodoModel ();
			todo.Id = id;
			todo.ProjectId = projectId;
			todo.Description = description.Text;
			todo.Date = todosDate.Text;
			if (todosType.Text.CompareTo (TYPE_BUG) == 0) {
				todo.Type = TodoModel.TypeBug;
			} else {
				todo.Type = TodoModel.TypeFeature;
			}
			if (todosStatus.Text.CompareTo (STATUS_NEW) == 0) {
				todo.Status = TodoModel.StatusNew;
			} else {
				todo.Status = TodoModel.StatusFixedOrImplemented;
			}
			// TODO Implement chosing color

			if (EventSaved != null) {
				EventSaved (this, new EventSaveArgs (todo));
			}
		}
		public async void OnTappedSelectType (object sender, EventArgs e)
		{
			var type = await rootPage.DisplayActionSheet("Select Todo type", OPTION_CANCEL, null, TYPE_BUG, TYPE_FEATURE);
			if (type.CompareTo (todosType.Text) != 0 && type.CompareTo (OPTION_CANCEL) != 0) {
				todosType.Text = type;
				if (todosStatus.Text.CompareTo (STATUS_NEW) != 0) {
					if (type.CompareTo (TYPE_BUG) == 0) {
						todosStatus.Text = STATUS_FIXED;
					} else {
						todosStatus.Text = STATUS_IMPLEMENTED;
					}
				}
			}
		}
		public async void OnTappedSelectStatus (object sender, EventArgs e)
		{
			var status = await rootPage.DisplayActionSheet("Select Todo type", OPTION_CANCEL, null, STATUS_NEW, todosType.Text.CompareTo(TYPE_BUG) == 0 ? STATUS_FIXED : STATUS_IMPLEMENTED);
			if (todosStatus.Text.CompareTo (status) != 0 && status.CompareTo (OPTION_CANCEL) != 0) {
				todosStatus.Text = status;
			}
		}
	}
}

