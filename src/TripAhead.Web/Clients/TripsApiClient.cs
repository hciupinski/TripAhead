using TripAhead.Trips.Contracts.Models;

namespace TripAhead.Web.Clients;

public class TripsApiClient(HttpClient httpClient)
{
    public async Task<List<TripViewModel>> GetTripsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<TripViewModel>>("/") ?? new List<TripViewModel>();
    }
}