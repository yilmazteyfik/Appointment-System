using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Auth.Login;

public sealed record LoginCommand(string UserNameOrEmail, string Password) : IRequest<Result<LoginCommandResponse>>;