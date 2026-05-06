using System;

namespace Identity.Contract.DTOs;

public sealed record PaginationDto<T>(int Page, int PageSize, int TotalItems, int TotalPages, List<T> Items);
