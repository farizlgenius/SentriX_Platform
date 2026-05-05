using System;

namespace Sentrix.Contract.UiNotification.DTOS;

public sealed class UiMessage
{     
      public string Topic { get; set; } = default!;
      public object Payload { get; set; } = default!;
}
