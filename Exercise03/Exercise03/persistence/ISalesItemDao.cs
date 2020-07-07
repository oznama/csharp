using System;
using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesItemDao
    {
        bool Save(SalesItem salesItem);
        bool Delete(int saleId);
        ArrayList FindAll();
        SalesItem FindById(int id);
        ArrayList FindByProductId(int productId);
        ArrayList FindBySaleId(int saleId);
    }
}