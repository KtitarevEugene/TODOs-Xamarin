﻿using System;
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
		public void ShowCreateProjectView (object sender, EventArgs e)
		{
			var createDialog = new CreateProjectView ();
			createDialog.CancelClicked += (s, args) => {
				contentPageArea.Children.Remove(createDialog);
			};
			createDialog.CreateClicked += async (s, args) => {
				var eventArgs = args as ActionSheetEventArgs;
				if (eventArgs != null) {
					if (String.IsNullOrEmpty(eventArgs.ProjectName)) {
						await DisplayAlert("Warning", "Please, enter new project name.", "OK");
					} else {
						App.DataBase.AddOrUpdateProject(new ProjectModel(eventArgs.ProjectName));
						projectsList.ItemsSource = App.DataBase.GetAllProjects ();
						contentPageArea.Children.Remove(createDialog);
					}
				}
			};
			contentPageArea.Children.Add (createDialog, new Rectangle (0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
		}
		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var selectedProject = e.SelectedItem as ProjectModel;
			if (selectedProject != null) {
				
				System.Diagnostics.Debug.WriteLine (String.Format ("selected project: id = {0}; name = {1};", selectedProject.Id, selectedProject.ProjectName));
			}
		}
	}
}
