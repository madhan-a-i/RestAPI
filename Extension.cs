using System;
using Restapi.Dtos;
using Restapi.Models;

namespace Restapi
{
    public static class Extension
    {
        public static ItemDto AsDtos(this mlItems item) {
            return new ()
            {
                Code = item.Code,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}