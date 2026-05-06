using System;

namespace Core.Domain.Entities;

public sealed class Feature
{
      public int Id {get; private set;}
      public string Name {get; private set;} = string.Empty;

      public Feature(int Id,string Name)
      {
            this.Id = Id;
            this.Name = Name;
      }
}
