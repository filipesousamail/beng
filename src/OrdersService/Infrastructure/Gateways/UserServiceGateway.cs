using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;

namespace beng.OrdersService.Infrastructure.Gateways;

public class UserServiceGateway : IUserServiceGateway
{
    private readonly HttpClient _userServiceHttpClient;

    public UserServiceGateway(HttpClient userServiceHttpClient)
    {
        _userServiceHttpClient = userServiceHttpClient;
    }
    
    public async Task<IEnumerable<User>> GetUsersAsync(string userName, string orderBy, string orderDirection, 
        int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var validOrderSubjects = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {"Id", "Name"};
        var curatedOrderBy = validOrderSubjects.Contains(orderBy) ? orderBy : nameof(User.Id);

        var users = await _userServiceHttpClient.GetFromJsonAsync<PagedList<User>>(
            $"api/v1/users?userName={userName}&orderBy={curatedOrderBy}&orderDirection={orderDirection}&pageIndex={pageIndex}&pageSize={pageSize}",
            cancellationToken);

        return users?.Items ?? Enumerable.Empty<User>();

    }
}