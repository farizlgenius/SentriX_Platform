using System;
using System.Net;
using Core.Application.DTOs;
using Core.Application.Exceptions;

namespace Core.Api.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      switch (ex)
      {
        case BadRequestException:
          await BadRequestExceptionHandler(context, ex);
          break;
        case NotFoundException:
          await NotFoundExceptionHandler(context, ex);
          break;
        default:
          await HandleException(context, ex);
          break;
      }
    }
  }

  private Task BadRequestExceptionHandler(HttpContext context, Exception ex)
  {
    // Log the exception (you can use a logging framework here)
    Console.WriteLine($"An error occurred: {ex.Message}");

    // Set the response status code and content
    context.Response.StatusCode = StatusCodes.Status400BadRequest;
    context.Response.ContentType = "application/json";

    var response = new BaseDto(System.Net.HttpStatusCode.BadRequest, ex.Message, DateTime.UtcNow);
    return context.Response.WriteAsJsonAsync(response);
  }


  private Task NotFoundExceptionHandler(HttpContext context, Exception ex)
  {
    // Log the exception (you can use a logging framework here)
    Console.WriteLine($"An error occurred: {ex.Message}");

    // Set the response status code and content
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    context.Response.ContentType = "application/json";

    var response = new BaseDto(System.Net.HttpStatusCode.NotFound, ex.Message, DateTime.UtcNow);
    return context.Response.WriteAsJsonAsync(response);
  }


  private Task HandleException(HttpContext context, Exception ex)
  {
    // Log the exception (you can use a logging framework here)
    Console.WriteLine($"An error occurred: {ex.Message}");

    // Set the response status code and content
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = "application/json";

    if (ex.InnerException is null)
    {
      return context.Response.WriteAsJsonAsync(new BaseDto(System.Net.HttpStatusCode.InternalServerError, ex.Message, DateTime.UtcNow));
    }
    else
    {
      return context.Response.WriteAsJsonAsync(
        new
        {
          Code = HttpStatusCode.InternalServerError,
          Timestamp = DateTime.UtcNow,
          Details = new
          {
            Exception = ex.Message,
            InnerException = ex.InnerException.Message
          }
        }
      );
    }

  }


}
