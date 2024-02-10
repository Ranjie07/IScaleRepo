using System.Text.Json.Nodes;

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

        public dynamic LoadMessurement(int id)
        {            
            try
            {
                request = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + "/id/stations/" + id + "/measures");
                request.Headers.Add("accept", "application/json");
                response = httpClient.Send(request);

                if (response.IsSuccessStatusCode)
                {
                    readData = response.Content.ReadAsStringAsync().Result;
                    var test = JsonObject.Parse(readData);
                    if (string.IsNullOrEmpty(Convert.ToString(test)))
                        throw new Exception("Not Data Found!");

                    return test;
                } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)                
                    throw new Exception("Requesting URL Not Found!");                
                else
                    throw new Exception("Not Data Found!");
                
            } catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }          
        }
    }
}
