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
		public Button TranslatorBtn { get; set; }

		public Button CallBtn { get; set; }

		public MainPage()
		{
			// creating my layout
			var myStackLayout = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Spacing = 5,
				Padding = new Thickness(
					10,
					Device.OnPlatform(30, 10, 10),
					10,
					10
				)
			};

			// items that will be inserted into the layout
			var phonewordLabel = new Label () {
				Text = "Enter a Phoneword"
			};
			var phonewordEntry = new Entry ();
			TranslatorBtn = new Button () { 
				Text = "Translate"
			};
			CallBtn = new Button () { 
				Text = "Call",
				IsEnabled = false
			};

			// inserting my items into the layout
			myStackLayout.Children.Add (phonewordLabel);
			myStackLayout.Children.Add (phonewordEntry);
			myStackLayout.Children.Add (TranslatorBtn);
			myStackLayout.Children.Add (CallBtn);

			// set click events for buttons
			TranslatorBtn.Clicked += translatorBtnClicked;

			this.Content = myStackLayout;
		}

		public void translatorBtnClicked(Object sender, EventArgs e)
		{
			CallBtn.IsEnabled = true;
		}
	}
}