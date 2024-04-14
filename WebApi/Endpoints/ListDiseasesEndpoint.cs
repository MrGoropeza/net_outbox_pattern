using Application.Diseases.List;
using WebApi.Endpoints.Filters;

namespace WebApi.Endpoints;

public class ListDiseasesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/diseases", EndpointHandler)
            .WithDescription("List diseases")
            .WithName("ListDiseases")
            .WithTags("Diseases")
            .WithOpenApi()
            .AddEndpointFilter<ValidationFilter<ListDiseasesRequest>>();
    }

    private static async Task<IResult> EndpointHandler(
        [AsParameters] ListDiseasesRequest request,
        IListDiseasesService listService
    )
    {
        var result = await listService.List(request);
        return Results.Ok(result);
    }
}
