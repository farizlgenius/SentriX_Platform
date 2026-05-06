using System;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Sentrix.Contract.Messaging.Constants;

namespace Core.Application.Services;

public class BrokerService(IMessagePublisher publisher) : IBrokerService
{
      public async Task<bool> TestBrokerService(MessageBrokerDto message)
      {
            await publisher.PublishAsync(RabbitMqConstants.UI.EXCHANGE,RabbitMqConstants.UI.TEST,message);
            return true;
      }
}
