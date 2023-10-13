using LightFireMoreTech5.Models.Routes;

namespace LightFireMoreTech5.Services.Interfaces
{
    public interface IPathService
    {
        Task<Models.Routes.Route> GetRouteAsync(RoutePoint start, RoutePoint finish, RouteType type, CancellationToken token);

	}
}
