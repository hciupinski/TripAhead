using TripAhead.Trips.Contracts.Models;

namespace TripAhead.Web.Clients;

public class ReservationsApiClient(HttpClient httpClient)
{
    public async Task<List<TripViewModel>> GetPendingReservationsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<TripViewModel>>("/") ?? new List<TripViewModel>();
    }
}