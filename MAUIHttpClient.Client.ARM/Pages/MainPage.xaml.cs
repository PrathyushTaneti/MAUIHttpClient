using MAUIHttpClient.Client.ARM.Services;
using System.Net.Http.Json;

namespace MAUIHttpClient.Client.ARM.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MainPage(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            this.httpClientFactory = httpClientFactory;
        }

        private async void OnAPIHttpsButtonClicked(object sender, EventArgs e)
        {
            var httpClient = this.httpClientFactory.CreateClient("default-maui-api");
            var response = await httpClient.GetAsync("/WeatherForecast");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ResultDataLabel.Text = content.ToString();
            }
        }
    }

}
