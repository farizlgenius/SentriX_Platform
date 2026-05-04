namespace Core.Api.Settings;

public class SwaggerSetting
{
  public static void Swagger(WebApplicationBuilder builder)
  {
    // Add services to the container.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new()
      {
        Title = "SentriX Core API",
        Version = "v1",
        Description = "API for Core in SentriX System",
        Contact = new()
        {
          Name = "SentriX Team",
          Email = "support@sentrix.com",
          Url = new Uri("https://sentrix.com")
        }

      });
    });
  }
}
