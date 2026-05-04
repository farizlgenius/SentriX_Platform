
using Core.Api.Middlewares;
using Core.Api.Settings;

namespace Core.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================
        // Setting Routing option
        // ==========================
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true; // optional
        });

        // ==========================
        // Read Config from application.json
        // ==========================
        ReadConfigSetting.ReadConfig(builder);


        // ==========================
        // Swagger Setting
        // ==========================
        SwaggerSetting.Swagger(builder);

        // ==========================
        // Database connection
        // ==========================
        DbConnectionSetting.DatabaseConnectionHelper(builder);

        // ==========================
        // DI Setting
        // ==========================
        DISetting.DependencyInjectionSetting(builder);

        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        /// ==========================
        /// Global Exception Handling Middleware
        /// ==========================
        app.UseMiddleware<GlobalExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
