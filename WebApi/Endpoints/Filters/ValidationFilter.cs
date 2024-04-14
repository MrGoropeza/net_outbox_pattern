using System.ComponentModel.DataAnnotations;
using System.Net;
using Dumpify;

namespace WebApi.Endpoints.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next
    )
    {
        T? arg = context.Arguments.Where(x => x is T).Cast<T>().FirstOrDefault();

        if (arg is null)
            return await next.Invoke(context);

        List<ValidationResult> validationResults = new();

        if (
            !Validator.TryValidateObject(
                arg,
                new ValidationContext(arg),
                validationResults,
                validateAllProperties: true
            )
        )
        {
            return Results.ValidationProblem(
                validationResults.ToDictionary(
                    x => x.ErrorMessage!.ToString(),
                    x => x.MemberNames.ToArray()
                ),
                statusCode: (int)HttpStatusCode.BadRequest
            );
        }

        return await next.Invoke(context);
    }
}
