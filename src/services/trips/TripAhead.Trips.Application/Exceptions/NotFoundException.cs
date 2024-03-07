using TripAhead.Common;

namespace TripAhead.Trips.Application.Exceptions;

public class NotFoundException<T>(Guid id) : Exception($"Entity of type: {nameof(T)} with id: {id} cannot be found.")
    where T : Entity;