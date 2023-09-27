using JwtStore.Core.Contexts.AccountContext.UseCases.Create;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwtStore.Infra.Contexts.AccountContext.UseCases.Create;
using MediatR;

namespace JwtStore.Api.Extensions;

public static class AccountContextExtension
{
    public static void AddAccountContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<IRepository, Repository>();
        builder.Services.AddTransient<IService, Service>();
        #endregion

    }

    public static void MapAccountEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/users", async (Request request, IRequestHandler<Request, Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
            ? Results.Created("", result)
            : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
