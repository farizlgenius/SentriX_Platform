using System;
using Identity.Domain.Constants;
using SentriX.BuildingBlock.Exceptions;

using Identity.Contract.Interfaces;
using Identity.Application.Interfaces;
using Identity.Contract.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public class SettingService(ISettingRepository repo) : ISettingService
{
      public async Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto)
      {
            if(dto.Len == 0 )
                  throw new BadRequestException(ResponseMessage.PasswordLenEmpty);

            var domain = new PasswordRule(dto.Id,dto.Len,dto.IsDigit,dto.IsLower,dto.IsSymbol,dto.IsUpper,dto.Weaks);
            
            var res = await repo.CreatePasswordRuleAsync(domain);
            return res;
      }

      public async Task<PasswordRuleDto> GetPassowrdRuleAsync()
      {
            var res  = await repo.GetPassowrdRuleAsync();
            return res;
      }
}
