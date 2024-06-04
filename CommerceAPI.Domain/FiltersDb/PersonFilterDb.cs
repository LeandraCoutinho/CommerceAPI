using CommerceAPI.Domain.Repositories;

namespace CommerceAPI.Domain.FiltersDb;

public class PersonFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}