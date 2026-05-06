using System;
using Core.Contract.DTOs;
using Core.Domain.Entities;

namespace Core.Application.Interfaces;

public interface ICardFormatRepository : IBaseRepository<CardFormatDto, CardFormat>
{

}
