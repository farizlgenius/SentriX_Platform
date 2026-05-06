namespace Identity.Contract.DTOs;

public sealed record UserInTokenDto(string UserId, string Username, int RoleId, string RoleName, int LocationId, string LocationName);