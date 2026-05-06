



using Identity.Contract.DTOs;

namespace Identity.Contract.Interfaces;

public interface ISettingService
{
       Task<PasswordRuleDto> GetPassowrdRuleAsync();
       Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto);
}
