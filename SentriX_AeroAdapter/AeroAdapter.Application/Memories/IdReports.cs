using System;
using AeroAdapter.Application.DTOs;
using AeroAdapter.Application.Interfaces;
using AeroAdapter.Domain.Constants;
using AeroAdapter.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AeroAdapter.Application.Memories;

public sealed class IdReports(IServiceScopeFactory sp)
{
     
       public List<Domain.Entities.IdReport> IdReportInMemory {get; set;} = new List<Domain.Entities.IdReport>();

       public async Task AddIdReport(IdReport reports)
      {
            using var scope = sp.CreateScope();
            var publish = scope.ServiceProvider.GetRequiredService<IMessagePublisher>();

            if(!IdReportInMemory.Any(x => x.Mac.Equals(reports.Mac)))
                  IdReportInMemory.Add(reports);

            List<IdReport> dtos = new List<IdReport>();
            
            foreach(var id in IdReportInMemory)
            {
                  dtos.Add(
                        new IdReport(
                              id.ScpId,
                              id.SerialNumber,
                              id.Mac,
                              id.Ip,
                              id.Port,
                              id.Fw
                              )
                  );
            }

            await publish.PublishAsync(MessageConstant.UI.UI_EXCHANGE,MessageConstant.UI.ID_REPORT_ADD,true); // Publish to Realtime Service
            
      }

      public void RemoveIdReport(string mac)
      {
            var data = IdReportInMemory.Where(x => x.Mac.Equals(mac)).FirstOrDefault();
            if(data == null)
                  return;

            IdReportInMemory.Remove(data);
      }

      public void UpdateIp(string mac,string ip)
      {
            var idreport = IdReportInMemory.FirstOrDefault(x => x.Mac.Equals(mac));
            if(idreport == null)
                  return;

            idreport.UpdateIp(ip);
      }

      public void UpdatePort(string mac,int port )
      {
            var idreport = IdReportInMemory.FirstOrDefault(x => x.Mac.Equals(mac));
            if(idreport == null)
                  return;

            idreport.UpdatePort(port);
      }

}