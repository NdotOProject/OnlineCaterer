
namespace OnlineCaterer.Domain.Constants;

public static class PaginationQuery
{
    public const string Name = "p";

    public static string? MakeUrl(string? url ,int page)
    {
        return $"{url}?{Name}={page}";
    }
}
