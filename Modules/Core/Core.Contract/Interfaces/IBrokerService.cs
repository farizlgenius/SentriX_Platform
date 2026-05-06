
using Core.Contract.DTOs;

namespace Core.Application.Interfaces;

public interface IBrokerService
{     
      Task<bool> TestBrokerService(MessageBrokerDto message);
}
