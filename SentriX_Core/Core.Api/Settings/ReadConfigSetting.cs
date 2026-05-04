using System;
using Core.Application.Interfaces;
using Core.Infrastructure.Messaging;

namespace Core.Api.Settings;

public sealed class ReadConfigSetting
{
  public static void ReadConfig(WebApplicationBuilder builder)
  {
    // ==========================
    // Read config from appsetting.json
    // ==========================

    builder.Services
           .AddOptions<RabbitMqOptions>()
           .Bind(builder.Configuration.GetSection("RabbitMQ"))
           .ValidateOnStart();

    builder.Services.AddSingleton<IRabbitMqOptions>(sp => sp.GetRequiredService<
        Microsoft.Extensions.Options.IOptions<RabbitMqOptions>>().Value);

    // builder.Services
    //        .AddOptions<HttpSetting>()
    //        .Bind(builder.Configuration.GetSection("HttpSetting"))
    //        .ValidateOnStart();

    // builder.Services
    //        .AddOptions<RabbitMqSetting>()
    //        .Bind(builder.Configuration.GetSection("RabbitMq"))
    //        .ValidateOnStart();
  }
}
