using System;
using Xamarin.Forms;

namespace PhonewordForms
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MainPage ();
		}
	}

	public class MainPage : ContentPage
	{
		public MainPage()
		{
			var myStackLayout = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Spacing = 20,
				Padding = new Thickness(
					5,
					Device.OnPlatform(20, 5, 5),
					5,
					5
				)
			};

			var testLabel = new Label () {
				Text = "My test label"
			};

			myStackLayout.Children.Add (testLabel);

			this.Content = myStackLayout;
		}
	}
}