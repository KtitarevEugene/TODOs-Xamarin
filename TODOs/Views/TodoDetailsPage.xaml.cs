using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Globalization;

namespace TODOs
{
	public partial class TodoDetailsPage : ContentView
	{
		private TodoModel model;
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
		public event EventSaveHandler SaveButtonClicked;
		public event EventHandler BackButtonClicked;
		public event EventHandler RemoveButtonClicked;

		public TodoDetailsPage (ContentPage page, int projectId) : this(page, new TodoModel() {ProjectId = projectId})
		{}
		public TodoDetailsPage (ContentPage page, TodoModel todo) : base()
		{
			InitializeComponent ();
			if (todo.Id == 0) {
				todosDate.Text = DateTime.Now.ToString ("ddd MMM dd yyyy HH:mm:ss");
			} else {
				todosDate.Text = todo.Date;
				todosType.Text = (todo.Type == TodoModel.TypeBug ? TYPE_BUG : TYPE_FEATURE);
				todosStatus.Text = (todo.Status == TodoModel.StatusNew ? STATUS_NEW : todo.Type == TodoModel.TypeBug ? STATUS_FIXED : STATUS_IMPLEMENTED);
				description.Text = todo.Description;
			}
			model = todo;
			rootPage = page;
		}
		private void OnBackButtonClicked(object sender, EventArgs e)
		{
			if (BackButtonClicked != null) {
				BackButtonClicked (this, new EventArgs ());
			}
		}
		private void OnRemoveButtonClicked(object sender, EventArgs e)
		{
			if (model.Id != 0) {
				if (RemoveButtonClicked != null) {
					RemoveButtonClicked (this, new EventArgs ());
				}
			}
		}
		private async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			if (description.Text != null && !String.IsNullOrEmpty (description.Text.Trim())) {
				model.Description = description.Text.Trim();
				model.Date = todosDate.Text;
				if (todosType.Text.CompareTo (TYPE_BUG) == 0) {
					model.Type = TodoModel.TypeBug;
				} else {
					model.Type = TodoModel.TypeFeature;
				}
				if (todosStatus.Text.CompareTo (STATUS_NEW) == 0) {
					model.Status = TodoModel.StatusNew;
				} else {
					model.Status = TodoModel.StatusFixedOrImplemented;
					model.Color = TodoModel.ColorGreen;
				}
				if (SaveButtonClicked != null) {
					SaveButtonClicked (this, new EventSaveArgs (model));
				}
			} else {
				await rootPage.DisplayAlert("Warning", "Please, enter todo's description.", "OK");
				description.Focus ();
			}
		}
		private async void OnTappedSelectType (object sender, EventArgs e)
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
		private async void OnTappedSelectStatus (object sender, EventArgs e)
		{
			var status = await rootPage.DisplayActionSheet("Select Todo status", OPTION_CANCEL, null, STATUS_NEW, todosType.Text.CompareTo(TYPE_BUG) == 0 ? STATUS_FIXED : STATUS_IMPLEMENTED);
			if (todosStatus.Text.CompareTo (status) != 0 && status.CompareTo (OPTION_CANCEL) != 0) {
				todosStatus.Text = status;
			}
		}
		private void OnTappedSelectColor (object sender, EventArgs e)
		{
			var imageControl = sender as Image;
			if (imageControl != null) {
				if (imageControl == white) {
					model.Color = TodoModel.ColorWhite;
				} else if (imageControl == yellow) {
					model.Color = TodoModel.ColorYellow;
				} else if (imageControl == red) {
					model.Color = TodoModel.ColorRed;
				} else {
					model.Color = TodoModel.ColorBlue;
				}
			}
		}
	}
}

