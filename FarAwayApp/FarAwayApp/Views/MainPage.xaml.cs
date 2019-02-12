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

        private void NavToQuest(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuestPage();
        }

        private void NavToID(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuestPage();
        }

        private void NavToDocument(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuestPage();
        }

        private void NavToMap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuestPage();
        }
    }
}