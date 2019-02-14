using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using FarAwayApp.Models;
using System.Collections.Generic;
using System.Collections;

namespace FarAwayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestPage : ContentPage
    {
        private static string allUsersURL = "http://10.166.210.168:3000/users";

        public ObservableCollection<string> Items { get; set; }

        public QuestPage()
        {
            InitializeComponent();
            SetDataAsync();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var content = e.Item as Users;
            DisplayAlert(content.Id.ToString(), content.Email.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public static async Task<dynamic> GetDataFromService()
        {
            using (var client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = await client.GetAsync(allUsersURL);
                    response.EnsureSuccessStatusCode();
                    List<Users> responseBody = JsonConvert.DeserializeObject<List<Users>>(await response.Content.ReadAsStringAsync());
                    return responseBody;
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }                
            }

        }

        private async void SetDataAsync()
        {
            List<Users> users = await GetDataFromService();
            UsersListView.ItemsSource = users;
        }
    }
}
