using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TODOs
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
		}
		public void OnFollowLinkClicked (object sender, EventArgs e)
		{
			Label linkLabel = sender as Label;
			try
			{
				Device.OpenUri (new Uri ("http://" + linkLabel.Text));
			}
			catch (Exception)
			{
				DisplayAlert ("Error", "Can't open browser.", "OK");
			}
		}
	}
}
