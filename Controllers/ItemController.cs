using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Restapi.Dtos;
using Restapi.Models;
using Restapi.Repositories;

namespace Restapi.Controller
{
    [ApiController]
    [Route("items")]
    public class ItemController: ControllerBase
    {
        private readonly IInMemItems repository;

        public ItemController(IInMemItems repository){
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems() 
        {
            return repository.GetItems().Select( i => i.AsDtos());
        }
        
        [HttpGet("{code}")]
        public ActionResult <ItemDto> GetItems(Guid code) 
        {
            var item = repository.GetItem(code);
            if (item == null)
            {
               return NotFound();
            }
            return item.AsDtos();
        }


         [HttpPost]
        public ActionResult<ItemDto> CreatedItems(CreateItemDto items) {
            mlItems item = new()
            {
                Code = Guid.NewGuid(),
                Name = items.Name,
                Price = items.Price,
                CreatedDate = DateTimeOffset.Now
            };
            repository.CreateItems(item);

            return CreatedAtAction(nameof(GetItems), new { Code = item.Code }, item.AsDtos());
        }

        [HttpPut("{code}")]
        public ActionResult UpdateItem(Guid code, UpdateItemDto UpdateItem){
            var existingItem = repository.GetItem(code);

            if (existingItem is null)
            {
                return NotFound();
            }

            mlItems item = existingItem with
            {
             Name = UpdateItem.Name,
             Price = UpdateItem.Price
            };

            repository.UpdateItem(code, item);
            return NoContent();
        }

         [HttpDelete("{code}")]
        public ActionResult DeleteItem(Guid code){
            var existingItem = repository.GetItem(code);

            if (existingItem is null)
            {
                return NotFound();
            }
       
            repository.DeleteItem(code);
            return NoContent();
        }
    }
}