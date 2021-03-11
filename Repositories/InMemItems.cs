using System;
using System.Collections.Generic;
using System.Linq;
using Restapi.Models;

namespace Restapi.Repositories
{
   
    public class InMemItems : IInMemItems
    {
        private readonly List<mlItems> Items = new()
        {
            new mlItems { Code = Guid.NewGuid(), Name = "Car", Price = 7, CreatedDate = DateTimeOffset.Now },
            new mlItems { Code = Guid.NewGuid(), Name = "Bike", Price = 8, CreatedDate = DateTimeOffset.Now },
            new mlItems { Code = Guid.NewGuid(), Name = "Truck", Price = 9, CreatedDate = DateTimeOffset.Now }
        };

        public IEnumerable<mlItems> GetItems()
        {
            return Items;
        }

        public mlItems GetItem(Guid code)
        {
            return Items.Where(Items => Items.Code == code).SingleOrDefault();
        }

        public void CreateItems(mlItems item)
        {
            Items.Add(item);
        }

        public void UpdateItem(Guid code, mlItems item)
        {
            var Index = Items.FindIndex(i => i.Code == code);
            Items[Index] = item;
        }  

        public void DeleteItem(Guid code)
        {
           var Index = Items.FindIndex(i => i.Code == code);
            Items.RemoveAt(Index);
        }
    }
}