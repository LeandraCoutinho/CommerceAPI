using MP.ApiDotNet7.Domain.Repositories;

namespace MP.ApiDotNet7.Domain.FiltersDb;

public class PersonFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}