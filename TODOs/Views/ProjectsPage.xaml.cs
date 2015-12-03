using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TODOs
{
	public partial class ProjectsPage : ContentPage
	{
		public ProjectsPage ()
		{
			InitializeComponent ();
			var list = App.DataBase.GetAllProjects ();
			projectsList.ItemsSource = list;
		}
		private void ShowCreateProjectView (object sender, EventArgs e)
		{
			var createDialog = new CreateProjectView ();
			createDialog.CancelClicked += (s, args) => {
				contentPageArea.Children.Remove(createDialog);
			};
			createDialog.CreateClicked += async (s, args) => {
				var eventArgs = args as ActionSheetEventArgs;
				if (eventArgs != null) {
					if (eventArgs.ProjectName != null && !String.IsNullOrEmpty(eventArgs.ProjectName.Trim())) {
						App.DataBase.AddOrUpdateProject(new ProjectModel(eventArgs.ProjectName.Trim()));
						projectsList.ItemsSource = App.DataBase.GetAllProjects ();
						contentPageArea.Children.Remove(createDialog);
					} else {
						await DisplayAlert("Warning", "Please, enter new project name.", "OK");
					}
				}
			};
			contentPageArea.Children.Add (createDialog, new Rectangle (0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
		}
		private void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var list = sender as CustomListView;
			var todosPage = new TodosPage (this);
			list.SelectedItem = null;
			todosPage.BackButtonClicked += (sender1, args) => {
				contentPageArea.Children.Remove(todosPage);
				projectsList.ItemsSource = App.DataBase.GetAllProjects ();
			};
			var selectedProject = e.SelectedItem as ProjectModel;
			if (selectedProject != null) {
				todosPage.ProjectId = selectedProject.Id;
				contentPageArea.Children.Add (todosPage, new Rectangle (0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
			}
		}
	}
}
