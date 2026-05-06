
using Identity.Domain.Entities;
using Identity.Contract.DTOs;


namespace Identity.Application.Interfaces;

public interface ISettingRepository
{
      Task<PasswordRuleDto> GetPassowrdRuleAsync();
      Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRule rule);
}
