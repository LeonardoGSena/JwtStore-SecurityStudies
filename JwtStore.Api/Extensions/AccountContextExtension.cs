using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwtStore.Infra.Contexts.AccountContext.UseCases.Create;

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

    }
}
