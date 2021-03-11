using System;

namespace Restapi.Models
{
public record mlItems
{
    public Guid Code { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}    
}