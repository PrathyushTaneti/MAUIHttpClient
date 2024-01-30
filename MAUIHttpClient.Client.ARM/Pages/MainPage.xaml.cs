using System.Net.Http.Json;

namespace MAUIHttpClient.Client.ARM.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAPIButtonClicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            // since localhost doesnot work on android change it to http
            var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5266" : "http://localhost:5266";
            var response = await httpClient.GetAsync($"{url}/WeatherForecast");
            var data = await response.Content.ReadAsStringAsync();
        }
    }

}
