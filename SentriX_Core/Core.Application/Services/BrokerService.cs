using System;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Core.Domain.Constants;

namespace Core.Application.Services;

public class BrokerService(IMessagePublisher publisher) : IBrokerService
{
      public async Task<bool> TestBrokerService(MessageBrokerDto message)
      {
            await publisher.PublishAsync(MessageConstants.Ui.EXCHANGE,MessageConstants.Ui.TEST,message);
            return true;
      }
}
