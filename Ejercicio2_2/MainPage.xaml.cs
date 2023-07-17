using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_2
{
    
    public partial class MainPage : ContentPage
    {
        private HttpClient _httpClient;
        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var json = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            var usuarios = JsonConvert.DeserializeObject<List<Json>>(json);
            list.ItemsSource = usuarios;
        }

        private async void btn_buscar_Clicked(object sender, EventArgs e)
        {

            int id;
            if (int.TryParse(Descrip.Text, out id))
            {
                var url = $"https://jsonplaceholder.typicode.com/posts/{id}";
                var json = await _httpClient.GetStringAsync(url);
                var item = JsonConvert.DeserializeObject<Json>(json);

                var itemList = new List<Json> { item };
                list.ItemsSource = itemList;
            }


        }
    }
}
