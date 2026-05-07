using System;
using System.Text;
using Identity.Application.Interfaces;
using Identity.Application.Services;
using Identity.Contract.Interfaces;
using Identity.Infrastructure.Authentication;
using Identity.Infrastructure.Helpers;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure;

public static class IdentityDependencyInjection
{
      public static IServiceCollection AddIdentityModule(
        this IServiceCollection services,
        IConfiguration configuration)
      {
            // ==========================
            // Authentication
            // ==========================
            var jwtCfg = configuration.GetSection("JwtSetting");
            var jwtSecret = jwtCfg["Secret"] ?? "THIS_IS_DEFAULT_SECRET";
            var issuer = jwtCfg["Issuer"];
            var audience = jwtCfg["Audience"];
            var accessTokenMinute = int.Parse(jwtCfg["AccessTokenMinutes"] ?? "60");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

            // Add Authentication
            services.AddAuthentication(
              options =>
            {
                  options.DefaultScheme = "SmartScheme";
                  // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                  // options.DefaultAuthenticateScheme = "SmartScheme";
                  // options.DefaultChallengeScheme = "SmartScheme";
            }
            )
            .AddPolicyScheme("SmartScheme", "JWT or API Key", options =>
            {
                  options.ForwardDefaultSelector = context =>
                  {
                        var hasApiKey = context.Request.Headers.ContainsKey("X-API-KEY");
                        var hasBearer = context.Request.Headers.ContainsKey("Authorization");
                        Console.WriteLine($"🔍 Authentication Header Check - HasApiKey: {hasApiKey}, HasBearer: {hasBearer}");

                        if (hasApiKey)
                              return "ApiKey";

                        if (hasBearer)
                              return JwtBearerDefaults.AuthenticationScheme;

                        // default if nothing provided
                        return JwtBearerDefaults.AuthenticationScheme;
                  };
            }).AddJwtBearer("Bearer", options =>
            {
                  //options.RequireHttpsMetadata = true; // set false only for local dev
                  //options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromSeconds(30)
                  };

                  options.Events = new JwtBearerEvents
                  {

                        OnMessageReceived = context =>
                {
                      // 1️⃣ HTTP requests (negotiate)
                      var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                      if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                      {
                            context.Token = authHeader.Substring("Bearer ".Length);
                            return Task.CompletedTask;
                      }

                      // 2️⃣ WebSocket requests (SignalR)
                      var accessToken = context.Request.Query["access_token"];
                      var path = context.HttpContext.Request.Path;

                      if (!string.IsNullOrEmpty(accessToken) &&
                  (path.StartsWithSegments("/sentrixHubs") ||
                   path.StartsWithSegments("/uiHubs")))
                      {
                            context.Token = accessToken;
                      }

                      return Task.CompletedTask;
                },
                        OnChallenge = async context =>
            {
                  context.HandleResponse(); // stop default 401 page

                  var message = "Jwt Token invalid or missing";

                  if (context.AuthenticateFailure != null)
                        message = context.AuthenticateFailure.Message;

                  await AuthResponseHelper.Write401(context.Response, message);
            },

                        OnForbidden = async context =>
                {
                      await AuthResponseHelper.Write403(context.Response);
                },

                        OnAuthenticationFailed = context =>
                {
                      Console.WriteLine("❌ JWT FAILED: " + context.Exception.Message);
                      return Task.CompletedTask;
                },

                        OnTokenValidated = context =>
                {
                      Console.WriteLine("✅ TOKEN VALIDATED");
                      return Task.CompletedTask;
                },




                  };
            })
            .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", options => { });

            // ==========================
            // Service
            // ==========================
            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<ISettingService,SettingService>();

            // ==========================
            // Repository
            // ==========================
            services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRefreshTokenAuditRepository, RefreshTokenAuditRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<ISettingRepository,SettingRepository>();

            // ==========================
            // Database
            // ==========================
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(
                configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));

            return services;
      }
}
