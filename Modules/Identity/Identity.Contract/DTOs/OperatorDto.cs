using System;
using System.Net;

namespace Identity.Contract.DTOs;

public sealed record OperatorDto(
  int Id,
  string UserId,
  string Username,
  string Title,
  string FirstName,
  string MiddleName,
  string LastName,
  string Gender,
  string Email,
  string Mobile,
  string Role
);
