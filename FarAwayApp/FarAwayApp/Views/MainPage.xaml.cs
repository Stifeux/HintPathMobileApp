using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarAwayApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        private async void NavToQuestAsync(object sender, EventArgs e) => await Navigation.PushModalAsync(new QuestPage());

        private async void NavToIDAsync(object sender, EventArgs e) => await Navigation.PushModalAsync(new QuestPage());

        private async void NavToDocumentAsync(object sender, EventArgs e) => await Navigation.PushModalAsync(new QuestPage());

        private async void NavToMapAsync(object sender, EventArgs e) => await Navigation.PushModalAsync(new QuestPage());
    }
}