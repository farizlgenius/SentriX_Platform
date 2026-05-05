using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IBrokerService
{     
      Task<bool> TestBrokerService(MessageBrokerDto message);
}
