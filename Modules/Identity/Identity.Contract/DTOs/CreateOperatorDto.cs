

namespace Identity.Contract.DTOs;

public record CreateOperatorDto(
  string OperatorId,
  string Username,
  string Password,
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
