using System;

namespace Core.Domain.Constants;

public sealed class MessageConstants
{
      public sealed class Device
      {
            public static string EXCHANGE = "device.exchange";
            public static string DEVICE_CREATED = "device.created";
            public static string DEVICE_UPDATED_IP = "device.updated.ip";
            public static string DEVICE_UPDATED_PORT = "device.updated.port";
      }

}
