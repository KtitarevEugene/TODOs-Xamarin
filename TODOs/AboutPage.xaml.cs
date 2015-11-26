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
		public void OnFollowLinkButtonClicked (object sender, EventArgs e)
		{
			Button linkButton = (Button)sender;
			try
			{
				Device.OpenUri (new Uri ("http://" + linkButton.Text));
			}
			catch (Exception)
			{
				DisplayAlert ("Error", "Can't open browser.", "OK");
			}
		}
	}
}
