using System;

namespace Identity.Contract.DTOs;

public record UpdateOperatorDto(
  int Id,
  string OperatorId,
  string Username,
  string title,
  string Firstname,
  string Middlename,
  string Lastname,
  string Gender,
  string Email,
  string Mobile,
  int RoleId,
  List<int> LocationId
  );