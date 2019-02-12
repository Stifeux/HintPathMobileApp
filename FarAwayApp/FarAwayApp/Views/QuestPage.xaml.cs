using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace FarAwayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public QuestPage()
        {

            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
        
            var getData = await getDataFromService();

            DisplayAlert("Item Tapped", getData[0].email.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public static async Task<dynamic> getDataFromService()
        {
            using (var client = new HttpClient())
            {
                var responseText = await client.GetStringAsync("http://10.166.210.168:3000/users");
                dynamic data = JsonConvert.DeserializeObject(responseText);
                return data;
            }

        }
    }
}
