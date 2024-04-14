using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Diseases.List;

public interface IListDiseasesService
{
    Task<ListDiseasesResponse> List(ListDiseasesRequest request);
}

public class ListDiseasesService(OutboxDbContext dbContext, IMapper mapper) : IListDiseasesService
{
    public async Task<ListDiseasesResponse> List(ListDiseasesRequest request)
    {
        var records = dbContext.Diseases.Where(r => r.DeletedAt == null);

        var count = await records.LongCountAsync();

        if (request is { OrderBy: not null })
        {
            var sortOrder =
                request.OrderByDescending.HasValue && request.OrderByDescending.Value
                    ? "desc"
                    : "asc";

            records = records.OrderBy($"{request.OrderBy} {sortOrder}");
        }

        if (request.PageSize > 0)
        {
            records = records.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
        }

        var result = await records
            .ProjectTo<DiseaseResponse>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new ListDiseasesResponse(result, count);
    }
}
