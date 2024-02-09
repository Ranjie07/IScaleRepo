using IScaleAPI.ViewModel;
using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace IScaleAPI.Repository.Rainfall
{
    public class RainfallService : IRainfallService
    {
        private HttpClient httpClient = new HttpClient();
        private HttpRequestMessage? request;
        private HttpResponseMessage? response;
        private string? readData;

        public RainfallService() {
            httpClient.BaseAddress = new Uri("http://environment.data.gov.uk/flood-monitoring");

        }

        public async Task<RainfallViewModel> LoadMessurement(int id)
        {
            RainfallViewModel? retDate = new RainfallViewModel();

            try
            {
                request = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + "/id/stations/" + id + "/measures");
                request.Headers.Add("accept", "application/json");
                response = httpClient.Send(request);

                if (response.IsSuccessStatusCode)
                {
                    readData = response.Content.ReadAsStringAsync().Result;
                    retDate = JsonConvert.DeserializeObject<RainfallViewModel>(readData);
                } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception("Requesting URL Not Found!");
                }
                else
                    throw new Exception("Not Data Found!");

                return retDate;
            } catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }          
        }
    }
}
