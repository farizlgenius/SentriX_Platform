using System;
using Identity.Contract.Enum;

namespace Identity.Contract.DTOs;

public sealed record RefreshTokenDto(
      string HashedToken,
      string UserId,
      string Username,
      string Action,
      DateTime ExpiredAt
);
