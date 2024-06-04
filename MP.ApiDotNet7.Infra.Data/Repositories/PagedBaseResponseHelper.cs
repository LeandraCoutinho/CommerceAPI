using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet7.Domain.Repositories;

namespace MP.ApiDotNet7.Infra.Data.Repositories;

public static class PagedBaseResponseHelper
{
    public static async Task<TResponse> GetResponseAsync<TResponse, T>
        (IQueryable<T> query, PagedBaseRequest request)
        where TResponse : PagedBaseResponse<T>, new()
    {
        var response = new TResponse();
        var count = await query.CountAsync(); // conta o numero de itens na consulta
        response.TotalPages = (int)Math.Abs((double)count / request.PageSize);
        response.TotalRegisters = count;
        if (string.IsNullOrEmpty(request.OrderByProperty))
            response.Data = await query.ToListAsync();
        else
            response.Data = query.OrderByDynamic(request.OrderByProperty)
                    .Skip((request.Page - 1) * request.PageSize) // vai pular as páginas
                    .Take(request.PageSize) // vai retonar a quantidade que tem
                    .ToList(); // vai retornar as páginas

        return response;
    }

    private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
    {
        return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
    }
    
}