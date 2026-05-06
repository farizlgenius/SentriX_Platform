using System;

namespace Identity.Contract.DTOs;

public sealed record TokenDto(
      string AccessToken,
      string RefreshToken,
      int ExpiredAt,
      DateTime RefreshExpiredAt
);
