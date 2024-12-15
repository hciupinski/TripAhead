using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TripAhead.Libs.Common.Interfaces;

namespace TripAhead.Services.Orders.Infrastructure.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id => Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Sid) ?? Guid.Empty.ToString());
}