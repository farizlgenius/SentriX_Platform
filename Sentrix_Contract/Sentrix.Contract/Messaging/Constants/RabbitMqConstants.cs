using System;

namespace Sentrix.Contract.Messaging.Constants;

public sealed class RabbitMqConstants
{
      public sealed class Device
      {
            public static string EXCHANGE = "device.exchange"; 
            public static string CREATED = "device.created";
            public static string UPDATED = "device.updated";
            public static string UPDATED_IP = "device.updated.ip";
            public static string UPDATED_PORT = "device.updated.port";
            public static string MEMORY_ALLOCATED = "deivce.memory";
            public static string IDREPORT = "device.idreport";
      }

      public sealed class UI
      {
            public static string EXCHANGE = "ui.exchange";
            public static string IDREPORT = "ui.idreport";
            public static string TEST = "ui.test";
      }
      
}

