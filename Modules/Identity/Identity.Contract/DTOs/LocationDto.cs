using System;

namespace Identity.Contract.DTOs;

public sealed record LocationDto(int Id, string Name, string Description, int CountryId, string Country);