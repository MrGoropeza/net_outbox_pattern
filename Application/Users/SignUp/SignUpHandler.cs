using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Persistence;
using Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.SignUp;

public interface ISignUpHandler
{
    Task SignUp(SignUpRequest request);
}

public class SignUpHandler(OutboxDbContext dbContext, IMapper mapper) : ISignUpHandler
{
    public async Task SignUp(SignUpRequest request)
    {
        if (dbContext.Users.Any(x => x.Email == request.Email))
        {
            throw new ValidationException("User with this email already exists");
        }

        var user = mapper.Map<SignUpRequest, User>(request);

        user.Hash = new PasswordHasher<string>().HashPassword(request.Email, request.Password);

        dbContext.Add(user);

        var outboxMessage = mapper.Map<SignUpRequest, OutboxMessage>(request);

        dbContext.Add(outboxMessage);

        await dbContext.SaveChangesAsync();
    }
}
