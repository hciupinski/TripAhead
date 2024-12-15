using TripAhead.Libs.Common.Base;

namespace TripAhead.Services.Trips.Domain.Events;

public class TripPublished(Guid TripId) : BaseEvent
{
}