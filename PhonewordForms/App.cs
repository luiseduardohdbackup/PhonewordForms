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
		private Button TranslatorBtn { get; set; }

		private Button CallBtn { get; set; }

		private Entry PhonewordEntry { get; set; }

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
			PhonewordEntry = new Entry ();
			TranslatorBtn = new Button () { 
				Text = "Translate"
			};
			CallBtn = new Button () { 
				Text = "Call",
				IsEnabled = false
			};

			// inserting my items into the layout
			myStackLayout.Children.Add (phonewordLabel);
			myStackLayout.Children.Add (PhonewordEntry);
			myStackLayout.Children.Add (TranslatorBtn);
			myStackLayout.Children.Add (CallBtn);

			// set click events for buttons
			TranslatorBtn.Clicked += translatorBtnClicked;
			CallBtn.Clicked += callBtnClicked;

			this.Content = myStackLayout;
		}

		public void translatorBtnClicked(Object sender, EventArgs e)
		{
			var textToTranslate = PhonewordEntry.Text;
			if (string.IsNullOrEmpty(textToTranslate)) {
				CallBtn.IsEnabled = false;
				CallBtn.Text = "Call";
				DisplayAlert ("Error", "You need to provide a word to translate.", "Ok", "Cancel");
				return;
			}

			var translatedText = Core.PhonewordTranslator.ToNumber (textToTranslate);
			CallBtn.IsEnabled = true;
			CallBtn.Text = "Call 1-800-" + translatedText;
		}

		public void callBtnClicked(Object sender, EventArgs e)
		{
			Console.WriteLine ("call that number yo");
		}
	}
}