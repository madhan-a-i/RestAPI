using System;

namespace Restapi.Dtos
{
    public record ItemDto
    {       
            public Guid Code { get; init; }
            public string Name { get; init; }
            public decimal Price { get; init; }
            public DateTimeOffset CreatedDate { get; init; }
      
    }
}