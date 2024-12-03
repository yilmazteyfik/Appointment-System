using Appointment_System_Server.Application.Service;
using Appointment_System_Server.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(
            p => p.UserName == request.UserNameOrEmail ||
                 p.Email == request.UserNameOrEmail, cancellationToken);
        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (!isPasswordCorrect)
        {
            return Result<LoginCommandResponse>.Failure("Password is wrong");
        }

        string token = jwtProvider.CreateToken(appUser);
        LoginCommandResponse response = new LoginCommandResponse(token);
        return Result<LoginCommandResponse>.Succeed(response);

    }
}