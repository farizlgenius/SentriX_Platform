using AeroAdapter.Application.Interfaces;
using AeroAdapter.Infrastructure;
using AeroAdapter.Infrastructure.Listener;
using Core.Infrastructure;
using Identity.Infrastructure;
using Notifier.Infrastructure;
using Notifier.Infrastructure.Hubs;
using SentriX.Api.Helpers;
using SentriX.Api.Middlewares;

namespace Identity.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================
        // Add SignalR
        // ==========================
        builder.Services.AddSignalR();

        // ==========================
        // Read config from appsetting.json
        // ==========================
        ReadConfigHelper.ReadConfig(builder);

        // ==========================
        // Cache service setting
        // ==========================
        CacheSettingHelper.RedisConfiguration(builder);


        // ==========================
        // Setting Routing option
        // ==========================
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true; // optional
        });

        // ==========================
        // Identity Module
        // ==========================

        builder.Services.AddIdentityModule(builder.Configuration);
        builder.Services.AddAeroModule(builder.Configuration);
        builder.Services.AddNotifyModule(builder.Configuration);
        builder.Services.AddCoreModule(builder.Configuration);




        // ==========================
        // Adding App Dependency Injection
        // ==========================
        DISettingHelper.DISetting(builder);

        // ==========================
        // Adding App Dependency Injection
        // ==========================
        CorsSettingHelper.Cors(builder);

        // ==========================
        // Add Authorization
        // ==========================
        builder.Services.AddAuthorization();

        // ==========================
        // Swagger Setting
        // ==========================
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        SwaggerSettingHelper.SwaggerSetting(builder);


        // ==========================
        // Add Controllers
        // ==========================
        builder.Services.AddControllers();


        var app = builder.Build();

        /// ==========================
        /// Global Exception Handling Middleware
        /// ==========================
        app.UseMiddleware<GlobalException>();


        /// ==========================
        /// Driver
        /// ==========================
        app.UseMiddleware<GlobalException>();
        var readDriver = app.Services.GetRequiredService<AeroMessageListener>();
        // var writer = app.Services.GetRequiredService<ICommandWriter>();
        readDriver.TurnOnDebug();


        using (var scope = app.Services.CreateScope())
            {
                var w = scope.ServiceProvider.GetRequiredService<IDriverWriter>();
                var w2 = scope.ServiceProvider.GetRequiredService<IScpWriter>();
                
                // Now you can safely use sys here
                if(!w.SystemLevelSpecification())
                {
                    Console.WriteLine("Initial driver failed. Shutting down app...");
                    app.Lifetime.StopApplication(); // graceful shutdown
                }

                // Now you can safely use sys here
                if(!w2.CreateChannel())
                {
                   Console.WriteLine("Initial driver failed. Shutting down app...");
                    app.Lifetime.StopApplication(); // graceful shutdown
                }
            }

            app.Lifetime.ApplicationStarted.Register(() =>
{
             _ = Task.Run(() => readDriver.GetTransactionUntilShutDownAsync());
            });


            app.Lifetime.ApplicationStopping.Register(async () =>
            {
                
                readDriver.SetShutDownFlag();
                readDriver.TurnOffDebug();
                
            });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("CorsPolicy");

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<NotifierHub>("/notiHubs");

        app.Run();
    }
}
