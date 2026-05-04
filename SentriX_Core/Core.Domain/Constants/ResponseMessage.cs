using System;

namespace Core.Domain.Constants;

public class ResponseMessage
{
  public static string NameEmpty = "Name must not empty.";
  public static string FirstnameEmpty = "Firstname must not empty.";
  public static string LastnameEmpty = "Lastname must not empty.";
  public static string EmailEmpty = "Email must not empty.";
  public static string DuplicatedName = "Found duplicate name.";
  public static string DuplicatedMac = "Found duplicate mac.";
  public static string DuplicatedSerialNumber = "Found duplicate serial number.";
  public static string LocationNotFound = "Location not found.";
  public static string LocationInvalid = "Location invalid.";
  public static string RecordNotFound = "Record not found.";
  public static string QueryIdInvalid = "Query id invalid.";
  public static string CompanyInvalid = "Company invalid.";
  public static string PositionInvalid = "Position invalid.";
  public static string DepartmentInvalid = "Department invalid.";
  public static string RoleInvalid = "Role invalid.";
}
