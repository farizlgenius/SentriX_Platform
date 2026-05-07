using System;
using Identity.Application.Services;
using Identity.Application.Settings;
using Identity.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using SentriX.Api.Middlewares;
using Identity.Contract.Interfaces;
using Identity.Application.Interfaces;
using AeroAdapter.Application.Interfaces;
using AeroAdapter.Infrastructure.Repositories;
using AeroAdapter.Application.Services;
using AeroAdapter.Infrastructure.Writer;
using AeroAdapter.Infrastructure.Listener;
using AeroAdapter.Application.Memories;

namespace SentriX.Api.Helpers;

public class DISettingHelper
{
  public static void DISetting(WebApplicationBuilder builder)
  {
    // ==========================
    // Adding Repository
    // ==========================
    
    // builder.Services.AddScoped<IScpRepository, ScpRepository>();
    // builder.Services.AddScoped<IWriterRepository, WriterRepository>();
    // builder.Services.AddScoped<IMpRepository, MpRepository>();

    // ==========================
    // Adding Service
    // ==========================
    
    // builder.Services.AddScoped<IScpService, ScpService>();

    // ==========================
    // Custom Service
    // ==========================
    builder.Services.AddTransient<GlobalException>();


    // ==========================
    // Writer Service
    // ==========================
    

    // // DI
    // builder.Services.AddHttpClient();
    // builder.Services.AddScoped<ICache, CacheRepository>();
    // builder.Services.AddTransient<ExceptionHandlingMiddleware>();

    // // DI Service
    // builder.Services.AddScoped<IAuth, AuthService>();
    // builder.Services.AddScoped<IRole, RoleService>();
    // builder.Services.AddScoped<IOperator, OperatorService>();

    // // DI Repository
    // builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    // builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
    // builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
    // builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    // builder.Services.AddScoped<ITokenRepository, TokenRepository>();
    // builder.Services.AddScoped<IHttpRepository, HttpRepository>();

    // Others
    


  }

}
