using Application.Users.SignUp;
using WebApi.Endpoints;
using WebApi.Endpoints.Filters;

namespace Application.Register;

public class SignUpEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-up", EndpointHandler)
            .WithDescription("Sign up")
            .WithName("SignUp")
            .WithTags("Auth")
            .WithOpenApi()
            .AddEndpointFilter<ValidationFilter<SignUpRequest>>();
    }

    private static async Task<IResult> EndpointHandler(
        SignUpRequest request,
        ISignUpHandler registerService
    )
    {
        await registerService.SignUp(request);

        Console.WriteLine($"User {request.Email} signed up");

        return Results.Ok();
    }
}
