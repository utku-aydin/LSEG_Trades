using System.Text.Json;
using System.Text;

using LSEG_Trades.Api.Controllers.HttpDataClient.Interfaces;
using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Data.Dtos;

namespace LSEG_Trades.Api.Controllers.HttpDataClient
{
    // DUA 05-12-2023: Demo class
    public class HttpExternalServiceClient : IExternalServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpExternalServiceClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<StockDto> GetPaymentResponse(StockDto stockDto)
        {
            string jsonString = JsonSerializer.Serialize(stockDto);
            var httpContent = new StringContent(
                jsonString,
                Encoding.UTF8,
                "application/json");

            var response = _httpClient.PostAsync($"http://localhost:8080/\r\n", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to authorise");
            }
            else
            {
                Console.WriteLine("Authorised");
            }

            string responseAsString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<StockDto>(responseAsString);
        }
    }
}
