using System;
using System.Collections.Generic;
using Restapi.Models;

public interface IInMemItems
    {
        mlItems GetItem(Guid code);
        IEnumerable<mlItems> GetItems();
        void CreateItems(mlItems item);
        void UpdateItem(Guid code, mlItems item);
        void DeleteItem(Guid code);
}