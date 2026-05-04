using System;

namespace Core.Application.Interfaces;

public interface ISockerService
{     
      Task<bool> TestSocketAsync(string message);
}
