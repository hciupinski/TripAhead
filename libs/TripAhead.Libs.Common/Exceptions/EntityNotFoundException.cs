using TripAhead.Libs.Common.Base;

namespace TripAhead.Libs.Common.Exceptions;

public class EntityNotFoundException<T>(Guid id) : Exception($"Entity of type: {nameof(T)} with id: {id} cannot be found.")
    where T : BaseEntity;