using System;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesItemDao
    {
        bool Save(SalesItem salesItem);
        bool Delete(int saleId);
        IList<SalesItem> FindAll();
        SalesItem FindById(int id);
        IList<SalesItem> FindByProductId(int productId);
        IList<SalesItem> FindBySaleId(int saleId);
    }
}