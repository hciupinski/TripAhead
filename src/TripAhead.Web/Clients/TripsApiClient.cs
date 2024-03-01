namespace TripAhead.Web.Clients;

public class TripsApiClient(HttpClient httpClient)
{
    public async Task<string> GetAsync()
    {
        return await httpClient.GetFromJsonAsync<string>("/") ?? "";
    }
}