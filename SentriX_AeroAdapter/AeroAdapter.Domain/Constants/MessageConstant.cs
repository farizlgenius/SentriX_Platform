using System;

namespace AeroAdapter.Domain.Constants;

public class MessageConstant
{
      public sealed class Device
      {
            public static string DEVICE_EXCHANGE = "device.exchange"; 
            public static string DEVICE_CREATED_KEY = "device.created";
            public static string DEVICE_UPDATED_KEY = "device.updated";
            public static string DEVICE_UPDATED_IP_KEY = "device.updated.ip";
            public static string DEVICE_UPDATED_PORT_KEY = "device.updated.port";
            public static string DEVICE_MEMORY_ALLOCATED_KEY = "deivce.memory";
            public static string DEVICE_IDREPORT = "device.idreport";
      }

      public sealed class UI
      {
            public static string UI_EXCHANGE = "iu.exchange";
            public static string ID_REPORT_ADD = "idreport.created";
      }
      
}
